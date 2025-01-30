using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PickleWebStore;
using PickleWebStore.Areas.ManagementPanel.Filters;
using PickleWebStore.Models;

namespace PickleWebStore.Areas.ManagementPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class ProductsController : Controller
    {
        private PickleWebDBModel db = new PickleWebDBModel();

        // GET: ManagementPanel/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.brand).Include(p => p.category).Include(p => p.manager).Where(p => p.IsDeleted == false);
            return View(products.ToList());
        }
        public ActionResult AllIndex()
        {
            var products = db.Products.Include(p => p.brand).Include(p => p.category).Include(p => p.manager).Where(p=>p.IsDeleted==true);
            return View(products.ToList());
        }

        // GET: ManagementPanel/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: ManagementPanel/Products/Create
        public ActionResult Create()
        {
            ViewBag.Brand_ID = new SelectList(db.Brands, "ID", "Name");
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.Manager_ID = new SelectList(db.Managers, "ID", "Name");
            return View();
        }

        // POST: ManagementPanel/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase productImage)
        {
            try
            {
                model.CreationTime = DateTime.Now;
                model.IsDeleted = false;
                model.Manager_ID = (Session["manager"] as Manager).ID;
                bool imageIsValid = false;
                if (productImage != null)
                {
                    FileInfo fi = new FileInfo(productImage.FileName);
                    if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                    {
                        imageIsValid = true;
                        Guid filename = Guid.NewGuid();
                        string fullname = filename + fi.Extension;
                        productImage.SaveAs(Server.MapPath("~/Assets/ProductImages/" + fullname));
                        model.Image = fullname;
                    }
                }
                else
                {
                    imageIsValid = true;
                    model.Image = "none.png";
                }
                if (imageIsValid)
                {
                    db.Products.Add(model);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagementPanel/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand_ID = new SelectList(db.Brands, "ID", "Name", product.Brand_ID);
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name", product.Category_ID);
            ViewBag.Manager_ID = new SelectList(db.Managers, "ID", "Name", product.Manager_ID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(int id,Product model,HttpPostedFileBase productImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    if (productImage != null)
                    {
                        bool imageIsValid = false;
                        FileInfo fi = new FileInfo(productImage.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                        {
                            imageIsValid = true;
                            Guid filename = Guid.NewGuid();
                            string fullname = filename + fi.Extension;
                            productImage.SaveAs(Server.MapPath("~/Assets/ProductImages/" + fullname));
                            model.Image = fullname;
                        }
                        if (imageIsValid)
                        {
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: ManagementPanel/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ManagementPanel/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            product.IsDeleted = true;
            product.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Products");
            }
            Product prod = db.Products.Find(id);
            if (prod == null)
            {
                return RedirectToAction("NotFound", "SystemMessages");
            }
            prod.IsDeleted = false;
            db.Entry(prod).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
            var products = db.Products.Include(p => p.brand).Include(p => p.category).Include(p => p.manager);
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Category_ID,Manager_ID,Brand_ID,Barcode,Name,Description,Price,Stock,ReorderLevel,CreationTime,Image,IsActive,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Brand_ID = new SelectList(db.Brands, "ID", "Name", product.Brand_ID);
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name", product.Category_ID);
            ViewBag.Manager_ID = new SelectList(db.Managers, "ID", "Name", product.Manager_ID);
            return View(product);
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

        // POST: ManagementPanel/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Category_ID,Manager_ID,Brand_ID,Barcode,Name,Description,Price,Stock,ReorderLevel,CreationTime,Image,IsActive,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brand_ID = new SelectList(db.Brands, "ID", "Name", product.Brand_ID);
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name", product.Category_ID);
            ViewBag.Manager_ID = new SelectList(db.Managers, "ID", "Name", product.Manager_ID);
            return View(product);
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

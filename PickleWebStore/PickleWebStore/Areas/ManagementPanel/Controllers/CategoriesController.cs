using PickleWebStore.Areas.ManagementPanel.Filters;
using PickleWebStore.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PickleWebStore.Areas.ManagementPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class CategoriesController : Controller
    {
        private PickleWebDBModel db = new PickleWebDBModel();

        // GET: ManagementPanel/Categories
        public ActionResult Index()
        {
            return View(db.Categories.Where(c => c.IsDeleted == false).ToList());
        }
        public ActionResult AllIndex()
        {
            return View(db.Categories.Where(c => c.IsDeleted == true).ToList());
        }

        // GET: ManagementPanel/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,IsActive,IsDeleted")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: ManagementPanel/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: ManagementPanel/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,IsActive,IsDeleted")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: ManagementPanel/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: ManagementPanel/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            category.IsDeleted = true;
            category.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReDelete(int? id)
        {
            if (id != null)
            {
                Category category = db.Categories.Find(id);
                category.IsDeleted = false;
                category.IsActive = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
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

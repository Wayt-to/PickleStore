using PickleWebStore.Areas.ManagementPanel.Filters;
using PickleWebStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PickleWebStore.Areas.ManagementPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class ManagersController : Controller
    {
        private PickleWebDBModel db = new PickleWebDBModel();

        // GET: ManagementPanel/Managers
        public ActionResult Index()
        {
            return View(db.Managers.Where(m => m.IsActive == true).ToList());
        }
        public ActionResult AllIndex()
        {
            return View(db.Managers.Where(m => m.IsActive == false).ToList());
        }


        // GET: ManagementPanel/Managers/Details/5
        public ActionResult Details(int? id)
        {

            Manager m = Session["manager"] as Manager;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (m.Type != "admin")
            {
                if (id != m.ID)
                {
                    return RedirectToAction("Index", "System");
                }
            }
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // GET: ManagementPanel/Managers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Managers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,Username,Mail,Password,CreationTime,LastLoginTime,IsActive,IsDeleted")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Managers.Add(manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manager);
        }

        // GET: ManagementPanel/Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            Manager m = Session["manager"] as Manager;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (m.Type != "admin")
            {
                if (id != m.ID)
                {
                    return RedirectToAction("Index", "System");
                }
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: ManagementPanel/Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,Username,Mail,Password,CreationTime,LastLoginTime,IsActive,IsDeleted")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        // GET: ManagementPanel/Managers/Delete/5
        public ActionResult Delete(int? id)
        {
            Manager manager = db.Managers.Find(id);
            manager.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReDelete(int? id)
        {
            Manager manager = db.Managers.Find(id);
            manager.IsActive = true;
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

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
    public class MembersController : Controller
    {
        private PickleWebDBModel db = new PickleWebDBModel();

        // GET: ManagementPanel/Members
        public ActionResult Index()
        {
            return View(db.Members.Where(m=>m.IsDeleted==false).ToList());
        }
        public ActionResult AllIndex()
        {
            return View(db.Members.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Status(int id, bool isActive)
        {
            var member = db.Members.Find(id);
            if (member != null)
            {
                member.IsActive = !isActive;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        // GET: ManagementPanel/Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: ManagementPanel/Members/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            member.IsActive=false;
            member.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Products");
            }
            Member prod = db.Members.Find(id);
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

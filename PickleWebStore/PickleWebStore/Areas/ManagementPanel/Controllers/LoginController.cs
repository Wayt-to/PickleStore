using PickleWebStore.Areas.ManagementPanel.Data;
using PickleWebStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickleWebStore.Areas.ManagementPanel.Controllers
{
    public class LoginController : Controller
    {
        PickleWebDBModel db = new PickleWebDBModel();
        // GET: ManagementPanel/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ManagerLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Manager m = db.Managers.FirstOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);
                if (m != null)
                {
                    if (m.IsActive)
                    {
                        Session["manager"] = m;
                        m.LastLoginTime = DateTime.Now;
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.warning = "Kullanıcı hesabınız sistem yöneticisi tarafından askıya alınmıştır";
                    }
                }
                else
                {
                    ViewBag.warning = "Kullanıcı bulunamadı";
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session["manager"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}
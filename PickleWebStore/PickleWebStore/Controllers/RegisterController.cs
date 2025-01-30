using PickleWebStore.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PickleWebStore.Controllers
{
    public class RegisterController : Controller
    {
        PickleWebDBModel db = new PickleWebDBModel();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Member model)
        {
            if (ModelState.IsValid)
            {
                if (model.Mail.Contains('@') && model.Mail.Contains('.'))
                {
                    var user = db.Members.FirstOrDefault(m => m.Mail == model.Mail);
                    var user2 = db.Members.FirstOrDefault(m => m.Username == model.Username);
                    if (user != null)
                    {
                        ViewBag.Warning = "Bu e-posta adresi zaten kullanılıyor.";
                        return View(model);
                    }
                    if (user2 != null)
                    {
                        ViewBag.Warning = "Bu kullanıcı adı mevcut, lütfen farklı bir tane seçin.";
                        return View(model);
                    }
                    model.CreationTime = DateTime.Now;
                    model.LastLoginTime = DateTime.Now;
                    model.IsActive = true;

                    db.Members.Add(model);
                    db.SaveChanges();
                    Session["user"] = model;

                    ViewBag.Success = "Kayıt başarılı! Giriş yapabilirsiniz.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Warning = "Lütfen geçerli bir e-posta giriniz.";
                    return View(model);
                }

            }

            return View(model);
        }
    }
}
using PickleWebStore.Models;
using System.Linq;
using System.Web.Mvc;
namespace PickleWebStore.Controllers
{
    public class LoginController : Controller
    {
        PickleWebDBModel db = new PickleWebDBModel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            Member user = db.Members.FirstOrDefault(m => m.Username == Username || m.Username == Username);
            if (user != null && user.Password == Password)
            {
                if (user.IsActive && user.IsDeleted == false)
                {
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Warning = "Hesabınız askıya alınmış.";
                }
            }
            else
            {
                ViewBag.Warning = "Kullanıcı adı veya şifre yanlış.";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}

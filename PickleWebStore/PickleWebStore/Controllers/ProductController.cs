using PickleWebStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace PickleWebStore.Controllers
{
    public class ProductController : Controller
    {
        PickleWebDBModel db = new PickleWebDBModel();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Product p = db.Products.Find(id);
            if (p == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Member user = Session["user"] as Member;
            if (user
                != null)
            {
                Favourite fav = db.Favourites.FirstOrDefault(f => f.Member_ID == user.ID && f.Product_ID == p.ID);
                ViewBag.IsFavorite = fav != null;
            }
            else
            {
                ViewBag.IsFavorite = false;
            }
            ViewBag.Others = db.Products.Where(b => b.Brand_ID == p.Brand_ID && b.IsActive == true && b.IsDeleted == false && b.ID != p.ID).ToList();
            ViewBag.OthersCat = db.Products.Where(b => b.Category_ID == p.Category_ID && b.IsActive == true && b.IsDeleted == false && b.ID != p.ID).ToList();
            return View(p);
        }



        public ActionResult AddToFavourites(int productId)
        {
            Member m = Session["user"] as Member;
            if (m != null)
            {
                Favourite favorite = db.Favourites.FirstOrDefault(f => f.Member_ID == m.ID && f.Product_ID == productId);

                bool isFavorite;

                if (favorite == null)
                {
                    favorite = new Favourite
                    {
                        Member_ID = m.ID,
                        Product_ID = productId
                    };
                    db.Favourites.Add(favorite);
                    db.SaveChanges();
                    isFavorite = true;
                }
                else
                {
                    db.Favourites.Remove(favorite);
                    db.SaveChanges();
                    isFavorite = false;
                }

                return RedirectToAction("Detail", "Product", new { id = productId, isFavorite });
            }
            ViewBag.Warning = "Lütfen giriş yapın.";
            return RedirectToAction("Index", "Login");
        }

    }
}
using PickleWebStore.Models;
using System.Linq;
using System.Web.Mvc;
namespace PickleWebStore.Controllers
{
    public class HomeController : Controller
    {
        PickleWebDBModel db = new PickleWebDBModel();
        // GET: Home
        public ActionResult Index()
        {
            var popularCategories = db.Products
    .GroupBy(p => p.Category_ID)
    .Select(g => new { CategoryId = g.Key, ProductCount = g.Count() })
    .OrderByDescending(g => g.ProductCount)
    .Take(5)
    .Join(db.Categories, p => p.CategoryId, c => c.ID, (p, c) => c)
    .Where(c => c.IsDeleted == false && c.IsActive == true)
    .ToList();

            ViewBag.categories = ViewBag.categories = popularCategories;

            return View(db.Products.Where(p => p.IsDeleted == false && p.IsActive == true).ToList());
        }
        public ActionResult Search(string letters)
        {
            if (letters != "")
            {
                ViewBag.search = letters;
                var products = db.Products
                    .Where(p => p.Name.Contains(letters) || p.Description.Contains(letters) || p.category.Name.Contains(letters))
                    .Where(p => p.IsActive == true && p.IsDeleted == false)
                    .ToList();
                return View(products);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult Category(int? id)
        {
            if (id != null)
            {
                Category cat = db.Categories.Find(id);
                ViewBag.cat = cat.Name;
                var products = db.Products
                    .Where(p => p.Category_ID == id && p.IsActive == true && p.IsDeleted == false)
                    .ToList();
                return View(products);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Brand(int? id)
        {
            if (id != null)
            {
                Brand brand = db.Brands.Find(id);
                ViewBag.cat = brand.Name;
                var products = db.Products
                    .Where(p => p.Brand_ID == id && p.IsActive == true && p.IsDeleted == false)
                    .ToList();
                return View(products);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

    }
}
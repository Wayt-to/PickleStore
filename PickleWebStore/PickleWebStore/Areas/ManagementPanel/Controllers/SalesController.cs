using PickleWebStore.Areas.ManagementPanel.Filters;
using PickleWebStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PickleWebStore.Areas.ManagementPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class SalesController : Controller
    {

        private PickleWebDBModel db = new PickleWebDBModel();

        // GET: ManagementPanel/Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Member).Include(s => s.Product);
            return View(sales.Where(s => s.IsActive == true).ToList());
        }
        public ActionResult AllIndex()
        {
            var sales = db.Sales.Include(s => s.Member).Include(s => s.Product);
            return View(sales.Where(s => s.IsActive == false).ToList());
        }

        // GET: ManagementPanel/Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: ManagementPanel/Sales/Create
        public ActionResult Create()
        {
            ViewBag.Member_ID = new SelectList(db.Members, "ID", "Name");
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Barcode");
            return View();
        }

        // POST: ManagementPanel/Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Product_ID,Member_ID,Address,Price,Quantity,TotalPrice,SaleTime,IsActive,IsDeleted")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Member_ID = new SelectList(db.Members, "ID", "Name", sale.Member_ID);
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Barcode", sale.Product_ID);
            return View(sale);
        }

        // GET: ManagementPanel/Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_ID = new SelectList(db.Members, "ID", "Name", sale.Member_ID);
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Barcode", sale.Product_ID);
            return View(sale);
        }

        // POST: ManagementPanel/Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Product_ID,Member_ID,Address,Price,Quantity,TotalPrice,SaleTime,IsActive,IsDeleted")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_ID = new SelectList(db.Members, "ID", "Name", sale.Member_ID);
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Barcode", sale.Product_ID);
            return View(sale);
        }

        // GET: ManagementPanel/Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            Sale sale = db.Sales.Find(id);

            sale.IsActive = false;

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ReDelete(int id)
        {
            Sale sale = db.Sales.Find(id);

            sale.IsActive = true;

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

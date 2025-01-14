using PickleWebStore.Areas.ManagementPanel.Filters;
using PickleWebStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using System.Xml;


namespace PickleWebStore.Areas.ManagementPanel.Controllers
{
    [ManagerAuthorizationFilter]
    public class HomeController : Controller
    {
        PickleWebDBModel db = new PickleWebDBModel();
        GeneralDataModel dm = new GeneralDataModel();
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Catalog.xml");
        // GET: ManagementPanel/Home
        public ActionResult Index()
        {
            if (db.Catalogs.Count()==0)
            {
                Catalog ct = new Catalog();
                ct.LastCheck = DateTime.Now;
                db.Catalogs.Add(ct);
                db.SaveChanges();
            }
            else
            {
                Catalog ct = db.Catalogs.Find(1);
                DateTime lastCheck = ct.LastCheck;
                bool Change = dm.HasXMLChanged(filePath, lastCheck);
                if (Change)
                {
                    ViewBag.XmlChanged = "Değişiklikler var";
                    List<string> existingBarcodes = db.Products.Select(p => p.Barcode).ToList();
                    List<XmlNode> newData = dm.Comparer(filePath,existingBarcodes);
                    ViewBag.NewData = newData;
                }
                db.SaveChanges();
            }
            List<string> remo = dm.GetXmlBarcodes(filePath);
            var removedProds = db.Products.Where(p => remo.Contains(p.Barcode)).ToList();
            ViewBag.Removed = removedProds;

            ViewBag.ProductCount = db.Products.Where(x => x.IsDeleted == false).Count();
            ViewBag.CategoryCount = db.Categories.Where(x => x.IsDeleted == false).Count();
            ViewBag.BrandCount = db.Brands.Where(x => x.IsDeleted == false).Count();
            ViewBag.MemberCount = db.Members.Where(x => x.IsDeleted == false).Count();
            ViewBag.SalesCount = db.Sales.Where(x => x.IsDeleted == false).Count();
            return View();
        }
        public ActionResult AddNewData()
        {
            Catalog ct = db.Catalogs.Find(1);
            List<string> existingBarcodes = db.Products.Select(p => p.Barcode).ToList();
            List<XmlNode> newData = dm.Comparer(filePath, existingBarcodes);
            ct.LastCheck = DateTime.Now;
            foreach (XmlNode node in newData)
            {
                int catid = dm.GetOrAddCategoryId(node["Category"].InnerText);
                int brandid = dm.GetOrAddBrandId(node["Brand"].InnerText);
                string barcode = node["Barcode"].InnerText;
                Product existingProduct = db.Products.FirstOrDefault(p=>p.Barcode==barcode);
                if (existingProduct!= null)
                {
                    existingProduct.Name = node["Name"].InnerText;
                    existingProduct.Price = Convert.ToDouble(node["Price"].InnerText);
                    existingProduct.Category_ID = catid; 
                    existingProduct.Brand_ID = brandid; 
                    db.SaveChanges();
                }
                else
                {
                    Product newProduct = new Product
                    {
                        Barcode = node["Barcode"].InnerText,
                        Name = node["Name"].InnerText,
                        Price = Convert.ToDouble(node["Price"].InnerText),
                        Category_ID = catid,
                        Brand_ID = brandid,

                    };
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult RemoveProduct()
        {
            List<string> barcodes = dm.GetXmlBarcodes(filePath);
            foreach (string item in barcodes)
            {
                Product product = db.Products.FirstOrDefault(p=>p.Barcode==item);
                if (product!=null)
                {
                    product.IsActive = false;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }
    }
}
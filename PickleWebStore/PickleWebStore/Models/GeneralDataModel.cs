using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace PickleWebStore.Models
{
    public class GeneralDataModel
    {
        PickleWebDBModel db = new PickleWebDBModel();
        public bool HasXMLChanged(string filepath, DateTime lastChecked)
        {
            DateTime lastModified = System.IO.File.GetLastWriteTime(filepath);
            return lastModified > lastChecked;
        }
        public List<XmlNode> Comparer(string xmlFilepath, List<string> existingBarcodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilepath);
            XmlNodeList allData = xmlDoc.GetElementsByTagName("Product");
            List<XmlNode> newData = new List<XmlNode>();

            foreach (XmlNode item in allData)
            {
                XmlNode nodeBarcode = item["Barcode"];
                XmlNode nodeName = item["Name"];
                XmlNode nodeBrand = item["Brand"];
                XmlNode nodeCategory = item["Category"];
                XmlNode nodePrice = item["Price"];

                string barcode = nodeBarcode != null ? nodeBarcode.InnerText : null;
                string name = nodeName != null ? nodeName.InnerText : null;
                string brand = nodeBrand != null ? nodeBrand.InnerText : null;
                string category = nodeCategory != null ? nodeCategory.InnerText : null;
                string price = nodePrice != null ? nodePrice.InnerText : null;
                foreach (string barc in existingBarcodes)
                {
                    Product p = db.Products.FirstOrDefault(pro => pro.Barcode == barc);
                    if (p != null && barcode != null && p.Barcode == barcode)
                    {
                        if (p.brand.Name != brand || p.category.Name != category || p.Price.ToString() != price || p.Name != name)
                        {
                            newData.Add(item);
                            break;
                        }

                    }
                    if (!existingBarcodes.Contains(barcode))
                    {
                        newData.Add(item);
                        break;
                    }
                }

            }
            return newData;
        }
        public List<string> GetXmlBarcodes(string xmlFilepath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilepath);

            XmlNodeList allData = xmlDoc.GetElementsByTagName("Product");
            List<string> xbarcodes = new List<string>();

            foreach (XmlNode item in allData)
            {
                string barcode = item["Barcode"].InnerText;
                xbarcodes.Add(barcode);
            }

            List<string> dbBarcodes = db.Products.Where(p => p.IsActive == true).Select(p => p.Barcode).ToList();

            List<string> removedProductBarcs = dbBarcodes.Except(xbarcodes).ToList();
            return removedProductBarcs;
        }
        public int GetOrAddCategoryId(string categoryName)
        {
            var category = db.Categories.SingleOrDefault(c => c.Name == categoryName);
            if (category == null)
            {
                category = new Category { Name = categoryName };
                db.Categories.Add(category);
                db.SaveChanges();
            }
            return category.ID;
        }
        public int GetOrAddBrandId(string BrandName)
        {
            var brand = db.Brands.SingleOrDefault(c => c.Name == BrandName);
            if (brand == null)
            {
                brand = new Brand { Name = BrandName };
                db.Brands.Add(brand);
                db.SaveChanges();
            }
            return brand.ID;
        }


    }


}
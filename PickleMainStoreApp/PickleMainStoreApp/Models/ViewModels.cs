using Org.BouncyCastle.Utilities.IO.Pem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickleMainStoreApp.Models
{
    public class ViewModels
    {
        public class ProductViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string BrandName { get; set; }
            public string Barcode { get; set; }
            public string CategoryName { get; set; }
            public double Price { get; set; }
            public short Stock { get; set; }
            public string EmployeeName { get; set; }
            public string Description { get; set; }
            public short ReorderLevel { get; set; }
            public DateTime CreationTime { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }

        }
        public class CategoryViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Employee { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
        }
        public class BrandViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Employee { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
        }
        public class SaleViewModel
        {
            public int ID { get; set; }
            public string ProductName { get; set; }
            public string ProductBarcode { get; set; }
            public string Brand { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public double Discount { get; set; }
            public double Total { get; set; }
            public DateTime SaleTime { get; set; }
            public string Costumer { get; set; }
            public string EmployeeName { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
        }
        public class PurchaseViewModel
        {
            public int ID { get; set; }
            public string ProductName { get; set; }
            public string ProductBarcode { get; set; }
            public string Brand { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public double Total { get; set; }
            public DateTime PurchaseTime { get; set; }
            public string Supplier { get; set; }
            public string EmployeeName { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
        }
        public class SupplierViewModel
        {
            public int ID { get; set; }
            public string CompName { get; set; }
            public string ContactName { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Mail { get; set; }
            public DateTime SaveTime { get; set; }
            public string EmployeeName { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
        }
        public class CustomerViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Mail { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string Type { get; set; }
            public double Discount { get; set; }
            public DateTime CreationTime { get; set; }
            public string EmployeeName { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
        }
        public class EmployeeViewModel
        {
            public int ID { get; set; }
            public string Username { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Phone { get; set; }
            public string Mail { get; set; }
            public string Password { get; set; }
            public DateTime CreationTime { get; set; }
            public DateTime LastLoginTime { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
            public string Type { get; set; }
        }
        public class TypesViewModel
        {
            public int ID { get; set; }
            public string TypeName { get; set; }
            public double Discount { get; set; }
            public bool IsActive { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}

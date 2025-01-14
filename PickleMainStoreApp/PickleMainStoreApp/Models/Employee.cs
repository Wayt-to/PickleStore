using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickleMainStoreApp.Models
{
    public class Employee
    {
        public Employee()
        {
            IsActive = true; IsDeleted = false; CreationTime = DateTime.Now;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public string Type { get; set; }
        
    }
}

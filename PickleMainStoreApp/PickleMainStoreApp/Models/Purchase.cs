using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickleMainStoreApp.Models
{
    public class Purchase
    {
        public Purchase()
        {
            IsActive = true; IsDeleted = false; PurchaseTime = DateTime.Now;
        }
        public int ID { get; set; }
        //
        public int? Product_ID { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
        //
        [Display(Name ="Adet")]
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }

        public Nullable<int> Employee_ID { get; set; }
        [ForeignKey("Employee_ID")]
        public virtual Employee Employee { get; set; }
        //
        public int? Supplier_ID { get; set; }
        [ForeignKey("Supplier_ID")]
        public virtual Supplier Supplier { get; set; }
        //
        public DateTime DocEditTime { get; set; }
        public DateTime PurchaseTime { get; set; }
        //
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        //
    }
}

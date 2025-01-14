using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickleMainStoreApp.Models
{
    public class Sale
    {
        public Sale()
        {
            IsActive = true; IsDeleted = false; SaleTime = DateTime.Now;
        }
        public int ID { get; set; }
        //
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Product Product { get; set; }
        //
        public double Price { get; set; }
        //
        public int Quantity { get; set; }
        //
        public double TotalPrice { get; set; }
        //
        public string Description { get; set; }
        //
        public DateTime SaleTime { get; set; }
        //
        public DateTime DocEditTime { get; set; }
        //
        public virtual Customer Customer { get; set; }
        //
        public virtual Employee Employee { get; set; }
        //
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        //
        public bool IsDeleted { get; set; }
        //
    }
}

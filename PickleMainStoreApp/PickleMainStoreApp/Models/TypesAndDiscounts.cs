using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickleMainStoreApp.Models
{
    public class TypesAndDiscounts
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public double Discount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PickleMainStoreApp.Models
{
    public class Supplier
    {
        public Supplier()
        {

        }
        public int ID { get; set; }
        [Display(Name ="Şirket İsmi")]
        public string CompanyName { get; set; }
        [Display(Name = "Şirket İsmi")]
        public string ContactName { get; set; }
        [Display(Name = "Şirket Adresi")]
        public string Adress { get; set; }
        [Display(Name = "Bağlantı Telefonu")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Bağlantı Mail")]
        public string ContactMail { get; set; }
        [Display(Name = "Durum")]
        public int? EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
        public DateTime SaveTime { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickleMainStoreApp.Models
{
    public class Customer
    {
        public Customer()
        {
            IsActive = true; IsDeleted = false; CreationTime = DateTime.Now;
        }
        public int ID { get; set; }
        //
        public int? Employee_ID { get; set; }
        [Display(Name = "Ekleme Yapan Eleman")]
        [ForeignKey("Employee_ID")]
        public virtual Employee Employee { get; set; }
        //
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "Bu alan Boş bırakılamaz.")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır.")]
        public string Name { get; set; }
        //
        [Display(Name = "Soyisim")]
        [Required(ErrorMessage = "Bu alan Boş bırakılamaz.")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır.")]
        public string Surname { get; set; }
        public string Phone { get; set; }
        //
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Bu alan Boş bırakılamaz.")]
        [StringLength(maximumLength: 150, ErrorMessage = "Bu alan en fazla 150 karakter olmalıdır.")]
        public string Mail { get; set; }
        //
        [Display(Name = "Kayıt Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }
        //
        public int? TypesAndDiscounts_ID { get; set; }
        [ForeignKey("TypesAndDiscounts_ID")]
        public virtual TypesAndDiscounts Type { get; set; }
       
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Adress { get; set; }
        //
        public virtual ICollection<Sale> Sales { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickleWebStore.Models
{
    public class Sale
    {
        public Sale()
        {
            IsActive = true; IsDeleted = false; SaleTime = DateTime.Now;
        }
        public int ID { get; set; }
        [Display(Name = "Ürün")]
        public int? Product_ID { get; set; }
        [Display(Name = "Ürün")]
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }
        [Display(Name = "Müşteri")]
        public int? Member_ID { get; set; }
        [Display(Name = "Müşteri")]
        [ForeignKey("Member_ID")]
        public virtual Member Member { get; set; }
        [DataType(DataType.MultilineText)]//View alanında text area oluşturur.
        [StringLength(maximumLength: 500, ErrorMessage = "En fazla 500 karakter olabilir.")]
        [Display(Name = "Teslimat Adresi")]
        public string Address { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public double Price { get; set; }
        [Display(Name = "Adet")]
        public int Quantity { get; set; }
        [Display(Name = "Satış Tutarı")]
        public double TotalPrice { get; set; }
        [Display(Name = "Satış Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SaleTime { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        //
        [Display(Name = "Silinmiş")]
        public bool IsDeleted { get; set; }
    }
}
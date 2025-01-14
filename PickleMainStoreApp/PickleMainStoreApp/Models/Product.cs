using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickleMainStoreApp.Models
{
    public class Product
    {
        public Product()
        {
            IsActive = true; IsDeleted = false; CreationTime = DateTime.Now;
        }
       
        public int ID { get; set; }
        public Nullable<int> Category_ID { get; set; }
        [Display(Name = "Kategori")]
        [ForeignKey("Category_ID")]

        public virtual Category Category { get; set; }//
        public Nullable<int> Employee_ID { get; set; }//
        [Display(Name = "Ekleyen")]
        [ForeignKey("Employee_ID")]
        public virtual Employee Employee { get; set; }//
        public int? Brand_ID { get; set; }//
        [Display(Name = "Marka")]
        [ForeignKey("Brand_ID")]
        public virtual Brand Brand { get; set; }//

        [Display(Name = "Barkod")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "En fazla 500 karakter olabilir.")]
        public string Barcode { get; set; }//

        
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 150, ErrorMessage = "En fazla 150 karakter olabilir.")]
        public string ProductName { get; set; }//

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "En fazla 500 karakter olabilir.")]
        public string Description { get; set; }//

        [Display(Name = "Fiyat")]
        public double Price { get; set; }//

        [Display(Name = "Stok")]
        public short Stock { get; set; }//

        [Display(Name = "Güvenlik Stoğu")]
        public short ReorderLevel { get; set; }//

        [Display(Name = "Ekleme Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }//
        [Display(Name = "Ürün Resmi")]
        [StringLength(maximumLength: 100)]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}

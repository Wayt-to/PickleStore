using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickleWebStore.Models
{
    public class Product
    {
        public Product()
        {
            IsActive = true; IsDeleted = false; CreationTime = DateTime.Now;
        }
        //ID isimli kolon otomatik olarak PRIMARY KEY ve IDENTITY(1,1) özelliğine sahip olur.
        public int ID { get; set; }
        [Display(Name = "Kategori")]
        public Nullable<int> Category_ID { get; set; }
        [Display(Name = "Kategori")]
        [ForeignKey("Category_ID")]

        public virtual Category category { get; set; }
        [Display(Name = "Ekleyen")]
        public Nullable<int> Manager_ID { get; set; }
        [Display(Name = "Ekleyen")]
        [ForeignKey("Manager_ID")]
        public virtual Manager manager { get; set; }
        public int? Brand_ID { get; set; }//Nullable ve int? , integer verinin null ifade alabilmesine olanak sağlar ancak işleme sırasında convert işlemini zorunlu tutar.
        [Display(Name = "Marka")]
        [ForeignKey("Brand_ID")]
        public virtual Brand brand { get; set; }

        [Display(Name = "Barkod")]
        [DataType(DataType.MultilineText)]//View alanında text area oluşturur.
        [StringLength(maximumLength: 500, ErrorMessage = "En fazla 500 karakter olabilir.")]
        public string Barcode { get; set; }

        //Required attribute'u kolonun veritabanında NOT NULL olmasını sağlar.
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 150, ErrorMessage = "En fazla 150 karakter olabilir.")]//Kolon nvarchar(150) oldu
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]//View alanında text area oluşturur.
        [StringLength(maximumLength: 500, ErrorMessage = "En fazla 500 karakter olabilir.")]
        public string Description { get; set; }


        [Display(Name = "Fiyat")]
        public double Price { get; set; }

        [Display(Name = "Stok")]
        public short Stock { get; set; }

        [Display(Name = "Güvenlik Stoğu")]
        public short ReorderLevel { get; set; }

        [Display(Name = "Ekleme Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }
        [Display(Name = "Ürün Resmi")]
        [StringLength(maximumLength: 100)]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Silinmiş")]
        public bool IsDeleted { get; set; }
    }
}
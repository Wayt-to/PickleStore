using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PickleWebStore.Models
{
    public class Category
    {
        public Category()
        {
            IsActive = true; IsDeleted = false;
        }
        //ID isimli kolon otomatik olarak PRIMARY KEY ve IDENTITY(1,1) özelliğine sahip olur.
        public int ID { get; set; }

        [Display(Name = "Kategori Adı")]
        //Required attribute'u kolonun veritabanında NOT NULL olmasını sağlar.
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 150, ErrorMessage = "En fazla 150 karakter olabilir.")]//Kolon nvarchar(150) oldu
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]//View alanında text area oluşturur.
        [StringLength(maximumLength: 500, ErrorMessage = "En fazla 500 karakter olabilir.")]
        public string Description { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        [Display(Name = "Silinmiş")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickleWebStore.Models
{
    public class Brand
    {
        public Brand()
        {
            IsActive = true; IsDeleted = false;
        }
        //ID isimli kolon otomatik olarak PRIMARY KEY ve IDENTITY(1,1) özelliğine sahip olur.
        public int ID { get; set; }

        [Display(Name = "Marka Adı")]
        //Required attribute'u kolonun veritabanında NOT NULL olmasını sağlar.
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 150, ErrorMessage = "En fazla 150 karakter olabilir.")]//Kolon nvarchar(150) oldu
        public string Name { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
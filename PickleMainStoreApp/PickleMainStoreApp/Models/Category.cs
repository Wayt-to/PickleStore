using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickleMainStoreApp.Models
{
    public class Category
    {
        public Category()
        {
            IsActive = true;IsDeleted = false;
        }

        public int ID { get; set; }
        [Display(Name ="Kategori Adı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz !")]
        [StringLength(maximumLength:150,ErrorMessage ="Bu alan fazla 150 karakter içerebilir.")]
        public string Name { get; set; }
        [Display(Name = "Kategori Adı")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "Bu alan fazla 500 karakter içerebilir.")]
        public string Description { get; set; }
        [Display(Name ="Durum")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? Employee_ID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

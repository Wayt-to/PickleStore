using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickleWebStore.Models
{
    public class Manager
    {
        public Manager()
        {
            IsActive = true;IsDeleted = false;CreationTime = DateTime.Now;
        }
        public int ID { get; set; }
        [Display(Name = "İsim")]
        [Required(ErrorMessage ="Bu alan Boş bırakılamaz.")]
        [StringLength(maximumLength:75,ErrorMessage ="Bu alan en fazla 75 karakter olmalıdır.")]
        public string Name { get; set; }
        [Display(Name = "Soyisim")]
        [Required(ErrorMessage = "Bu alan Boş bırakılamaz.")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır.")]
        public string Surname { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Bu alan Boş bırakılamaz.")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan en fazla 75 karakter olmalıdır.")]
        public string Username { get; set; }
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Bu alan Boş bırakılamaz.")]
        [StringLength(maximumLength: 150, ErrorMessage = "Bu alan en fazla 150 karakter olmalıdır.")]
        public string Mail { get; set; }
        [Display(Name ="Şifre")]
        [Required(ErrorMessage = "Bu alan Boş bırakılamaz.")]
        [StringLength(maximumLength: 20,MinimumLength =6, ErrorMessage = "Bu alan 6-20 karakter arasında olmalıdır.")]
        public string Password { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }
        [Display(Name = "Son Giriş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-mm-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime LastLoginTime { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Product> Products { get; set; }
}
}
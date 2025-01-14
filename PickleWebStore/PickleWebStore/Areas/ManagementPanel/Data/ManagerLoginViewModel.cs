using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickleWebStore.Areas.ManagementPanel.Data
{
    public class ManagerLoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Mail Zorunludur")]
        public string Mail { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre zorunludur")]
        public string Password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Identity.Models
{
    public class UserSignInViewModel
    {
        [Display(Name ="Kulanıcı Adınız: ")]
        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur.")]
        public string Username { get; set; }
        [Display(Name = "Şifreniz : ")]
        [Required(ErrorMessage = "Şifre Zorunludur.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

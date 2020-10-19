using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Şifre Alanını Doldurmak Zorunludur.")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar Alanını Doldurmak Zorunludur.")]
        public string SifreTekrar { get; set; }
    }
}
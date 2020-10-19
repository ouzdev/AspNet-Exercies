using System;
using System.Collections.Generic;
using System.Linq;
using OnlineKutuphanem.Models.Entity;
using System.Web;

namespace OnlineKutuphanem.Models.ViewModels
{
    public class ViewModel
    {
        public IEnumerable<Kitap> Kitaplar { get; set; }
        public IEnumerable<Hakkimizda> Hakkimizdas { get; set; }
        public IEnumerable<Uyeler> UyeSayisi { get; set; }
        public IEnumerable<Hareket> OduncSayisi { get; set; }
    }
}
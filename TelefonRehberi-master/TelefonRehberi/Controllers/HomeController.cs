using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Models;
using TelefonRehberi.Models.EntityFramework;
using PagedList;
using PagedList.Mvc;

namespace TelefonRehberi.Controllers
{
    public class HomeController : Controller
    {
        // Context nesnemi oluşturdum.
        DatabaseContext db = new DatabaseContext();

        public ActionResult Index(int sayfa = 1)
        {   // Tüm personel kayıtlarımı prs adında "var" tipinde değişkene atadım.

            // Ayrıca PagedList kütüphanesini kullanarak sayfalama yapısını kullandım.

            var prs = db.Personeller.ToList().ToPagedList(sayfa, 10);

            // Geri dönüş değeri için ise prs değişkenini sayfama gönderdim.    

            return View(prs);
        }

    }
}
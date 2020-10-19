using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Models.EntityFramework;

namespace TelefonRehberi.Controllers
{
    public class DetayController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Personel(int?id)
        {
         var detay = db.Personeller.Find(id);
            ViewBag.isim = detay.AD + " " + detay.SOYAD;
            ViewBag.telefon = detay.TELEFON;
            ViewBag.departman = detay.Departman.DepartmanAd;
            ViewBag.yonetici = detay.YONETICIAD;
            ViewBag.detay = detay.DETAY;

            return PartialView("_PartialPersonelDetail");
        }
    }
}
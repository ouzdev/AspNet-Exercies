using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineKutuphanem.Models.Entity;
using OnlineKutuphanem.Models.ViewModels;
namespace OnlineKutuphanem.Controllers
{
    public class IstatisliklerController : Controller
    {
        // GET: Istatislikler
        OnlineKutuphanemDBEntities db = new OnlineKutuphanemDBEntities();
        public ActionResult Index()
        {
            decimal KasaTutari =(decimal)db.Cezalar.Sum(x=>x.PARA);
            int KitapSayisi = db.Kitap.Count();
            int UyeSayisi = db.Uyeler.Count();
            int oduncKitapSayisi = db.Hareket.Where(x => x.ISLEMDURUM == false).Count();
            ViewBag.KasaTutarı = KasaTutari;
            ViewBag.KitapSayi = KitapSayisi;
            ViewBag.OduncSayi = oduncKitapSayisi;
            ViewBag.UyeSayisi = UyeSayisi;
            return View();
        }
    }
}
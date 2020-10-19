using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineKutuphanem.Models.Entity;

namespace OnlineKutuphanem.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        OnlineKutuphanemDBEntities db = new OnlineKutuphanemDBEntities();
        public ActionResult Index()
        {
            var listele = db.Hareket.Where(x => x.ISLEMDURUM == false).ToList();
            return View(listele);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(Hareket hrkt)
        {
            db.Hareket.Add(hrkt);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult OduncIade(Hareket p)
        {

            var oduncliste = db.Hareket.Find(p.ID);
            DateTime d1 = DateTime.Parse(oduncliste.IADETARIHI.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var sonuc = d2 - d1;
            ViewBag.gecGun = sonuc.TotalDays;
            return View(oduncliste);
        }
        [HttpPost]
        public ActionResult OduncIadeGuncelle(Hareket hrkt)
        {
            var eklenecekhareket = db.Hareket.Find(hrkt.ID);
            eklenecekhareket.UYEGETIRTARIH = hrkt.UYEGETIRTARIH;
            eklenecekhareket.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Odunc");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineKutuphanem.Models.Entity;
using System.Web.Mvc;
using System.Data.Entity.Validation;


namespace OnlineKutuphanem.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        OnlineKutuphanemDBEntities db = new OnlineKutuphanemDBEntities();
        public ActionResult Index()
        {
            var yazarListe = db.Yazar.ToList();

            return View(yazarListe);
        }
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(Yazar y)
        {
            db.Yazar.Add(y);
            db.SaveChanges();
            return RedirectToAction("Index", "Yazar");
        }
        public ActionResult YazarSil(int id)
        {
            var silinecek = db.Yazar.Find(id);
            db.Yazar.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGuncelle(int id)
        {
            var yazargetir = db.Yazar.Find(id);
            return View(yazargetir);
        }
        [HttpPost]
        public ActionResult YazarGuncelle(Yazar yzr)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarGuncelle");
            }
            var guncellenecek = db.Yazar.Find(yzr.ID);
            guncellenecek.AD = yzr.AD;
            guncellenecek.SOYAD = yzr.SOYAD;
            guncellenecek.DETAY = yzr.DETAY;

            db.SaveChanges();
            return RedirectToAction("Index", "Yazar");


        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineKutuphanem.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace OnlineKutuphanem.Controllers
{
    public class UyelerController : Controller
    {
        // GET: Uyeler
        OnlineKutuphanemDBEntities db = new OnlineKutuphanemDBEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var uyeler = db.Uyeler.ToList().ToPagedList(sayfa, 5);
            return View("Index",uyeler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(Uyeler uye)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.Uyeler.Add(uye);
            db.SaveChanges();
            return RedirectToAction("Index", "Uyeler");
        }
        [HttpGet]
        public ActionResult UyeGuncelle(int id)
        {
            var guncellegetir = db.Uyeler.Find(id);
            return View(guncellegetir);
        }
        [HttpPost]
        public ActionResult UyeGuncelle(Uyeler uye)
        {
                var guncellenecekuye = db.Uyeler.Find(uye.ID);
                guncellenecekuye.AD = uye.AD;
                guncellenecekuye.SOYAD = uye.SOYAD;
                guncellenecekuye.MAİL = uye.MAİL;
                guncellenecekuye.KULLANICIADI = uye.KULLANICIADI;
                guncellenecekuye.SIFRE = uye.SIFRE;
                guncellenecekuye.TELEFON = uye.TELEFON;
                guncellenecekuye.FOTOGRAF = uye.FOTOGRAF;
                guncellenecekuye.OKUL = uye.OKUL;
                db.SaveChanges();

                return View();
            
          

         
        }
        public ActionResult UyeSil(int id)
        {
            var silinecekuye = db.Uyeler.Find(id);
            db.Uyeler.Remove(silinecekuye);
            db.SaveChanges();
            return RedirectToAction("Index","Uyeler");
        }
    }
}
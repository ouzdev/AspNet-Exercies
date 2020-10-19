using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineKutuphanem.Models.Entity;

namespace OnlineKutuphanem.Controllers
{

    public class KitapController : Controller
    {
        OnlineKutuphanemDBEntities db = new OnlineKutuphanemDBEntities();    // GET: Kitap
        public ActionResult Index(string p)
        {
            var item = from i in db.Kitap select i;
            if (!string.IsNullOrEmpty(p))
            {
                item = item.Where(k => k.AD.Contains(p));
            }
            return View(item.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> kategori = (from i in db.Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AD,
                                                 Value = i.ID.ToString()
                                             }
                                         ).ToList();


            List<SelectListItem> yazar = (from i in db.Yazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD + " " + i.SOYAD,
                                              Value = i.ID.ToString()
                                          }
                ).ToList();
            ViewBag.kategori = kategori;
            ViewBag.yazar = yazar;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Kitap ktp)
        {
            var kategori = db.Kategori
                .Where(k => k.ID == ktp.KATEGORI).FirstOrDefault();
            var yazar = db.Yazar.Where(y => y.ID == ktp.YAZAR).FirstOrDefault();

            ktp.Kategori1 = kategori;
            ktp.Yazar1 = yazar;
            db.Kitap.Add(ktp);
            db.SaveChanges();

            return RedirectToAction("Index", "Kitap");
        }
        [HttpGet]
        public ActionResult KitapGuncelle(int id)
        {
            var getir = db.Kitap.Find(id);
            List<SelectListItem> kategori = (from i in db.Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AD,
                                                 Value = i.ID.ToString()
                                             }
                              ).ToList();
            List<SelectListItem> yazar = (from i in db.Yazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD + " " + i.SOYAD,
                                              Value = i.ID.ToString()
                                          }
                ).ToList();

            ViewBag.kategori = kategori;
            ViewBag.yazar = yazar;

            return View("KitapGuncelle", getir);

        }
        [HttpPost]
        public ActionResult KitapGuncelle(Kitap ktp)
        {
            var guncelle = db.Kitap.Find(ktp.ID);
            guncelle.AD = ktp.AD;
            var kategori = db.Kategori.Where(k => k.ID == ktp.Kategori1.ID).FirstOrDefault();
            var yazar = db.Yazar.Where(y => y.ID == ktp.Yazar1.ID).FirstOrDefault();
            guncelle.Kategori1 = kategori;
            guncelle.Yazar1 = yazar;
            guncelle.BASIMYILI = ktp.BASIMYILI;
            guncelle.SAYFASAYFASI = ktp.SAYFASAYFASI;
            guncelle.YAYIMEVİ = ktp.YAYIMEVİ;
            guncelle.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Kitap");

        }
        public ActionResult KitapSil(int id)
        {
            var silinecekkitap = db.Kitap.Find(id);
            db.Kitap.Remove(silinecekkitap);
            db.SaveChanges();
            return RedirectToAction("Index", "Kitap");

        }
    }
}
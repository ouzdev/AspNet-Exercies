using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineKutuphanem.Models.Entity;

namespace OnlineKutuphanem.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        OnlineKutuphanemDBEntities db = new OnlineKutuphanemDBEntities();

        public ActionResult Index()
        {
            var sonuc = db.Kategori.ToList();
            return View(sonuc);
        }
        public ActionResult KategoriEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori eleman)
        {
            db.Kategori.Add(eleman);
            db.SaveChanges();

            return RedirectToAction("Index", "Kategori");
        }
        public ActionResult KategoriSil(int id)
        {
            var silinecekelemanbul = db.Kategori.Find(id);
            db.Kategori.Remove(silinecekelemanbul);
            db.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }
        public ActionResult KategoriAl(int id)
        {
            var alinaneleman = db.Kategori.Find(id);
            return View(alinaneleman);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriGuncelle");
            }
            var alinaneleman = db.Kategori.Find(p.ID);
            alinaneleman.AD = p.AD;
            db.SaveChanges();

            return RedirectToAction("Index", "Kategori");
        }

         
    }
}
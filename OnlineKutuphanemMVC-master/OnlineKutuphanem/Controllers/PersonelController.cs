using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineKutuphanem.Models.Entity;

namespace OnlineKutuphanem.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        OnlineKutuphanemDBEntities db = new OnlineKutuphanemDBEntities();
        public ActionResult Index()
        {
            var personel = db.Personel.ToList();
            return View("Index", personel);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel prs)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.Personel.Add(prs);
            db.SaveChanges();
            return RedirectToAction("Index", "Personel");
        }
        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            var personelgetir = db.Personel.Find(id);
            return View(personelgetir);
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel prs)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGuncelle");
            }
            var guncellepersonel = db.Personel.Find(prs.ID);
            guncellepersonel.PERSONEL1 = prs.PERSONEL1;
            db.SaveChanges();
            return RedirectToAction("Index", "Personel");
        }

        public ActionResult PersonelSil(int id)
        {
            var silinecekpersonel = db.Personel.Find(id);
            db.Personel.Remove(silinecekpersonel);
            db.SaveChanges();
            return RedirectToAction("Index", "Personel");
        }
    }
}
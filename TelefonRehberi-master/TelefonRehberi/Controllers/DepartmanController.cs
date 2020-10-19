using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Models.EntityFramework;
using TelefonRehberi.Models;


namespace TelefonRehberi.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var departmanlar = db.Departmanlar.ToList();
            return View(departmanlar);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            db.Departmanlar.Add(departman);
            db.SaveChanges();
            return RedirectToAction("Index", "Departman");
        }
        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            var departmanCek = db.Departmanlar.Find(id);

            return View("DepartmanGuncelle", departmanCek);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman departman)
        {

            if (!ModelState.IsValid)
            {
                return View();

            }
            var departmanGuncelle = db.Departmanlar.Find(departman.ID);
            departmanGuncelle.DepartmanAd = departman.DepartmanAd;
            db.SaveChanges();
            return View("Index", db.Departmanlar.ToList());
        }

        public ActionResult DepartmanSil(int id)
        {
            var silinecekDepartman = db.Departmanlar.Find(id);
            bool kontrol = false;
            foreach (var item in db.Personeller)
            {

                if (silinecekDepartman.ID == item.DepartmanID)
                {
                    kontrol = true;
                    break;
                }

            }
            if (!kontrol)
            {
                db.Departmanlar.Remove(silinecekDepartman);
                db.SaveChanges();
                return RedirectToAction("Index", "Departman");
            }
            else
            {
                ViewBag.hata = "Silmek İstediğiniz Departmanda Kayıtlı Personeller mevcut olduğu için departmanı silemezsiniz.";
                return View("Index", db.Departmanlar.ToList());
            }

        }
    }
}
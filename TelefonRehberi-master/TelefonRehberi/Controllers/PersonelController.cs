using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Models;
using TelefonRehberi.Models.EntityFramework;
using PagedList;
using PagedList.Mvc;
using TelefonRehberi.Models.ViewModels;

namespace TelefonRehberi.Controllers
{
    public class PersonelController : Controller
    {

        DatabaseContext db = new DatabaseContext();

        public ActionResult Index(int sayfa = 1)
        { 
            var personel = db.Personeller.ToList();
            
            return View(personel.ToPagedList(sayfa, 10));
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departman = (from p in db.Departmanlar.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = p.DepartmanAd,
                                                  Value = p.ID.ToString()
                                              }).ToList();

            List<SelectListItem> yonetici = (from p in db.Personeller.ToList()
                                              select new SelectListItem
                                             {
                                                 Text = p.AD + " " + p.SOYAD,
                                                 Value = p.ID.ToString()
                                             }).ToList();

            ViewBag.departman = departman;
            ViewBag.yonetici = yonetici;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            ModelState.Remove("DETAY");
            ModelState.Remove("YONETICIAD");
            ModelState.Remove("YONETICI");
            if (!ModelState.IsValid)
            {
                List<SelectListItem> departmans = (from p in db.Departmanlar.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = p.DepartmanAd,
                                                      Value = p.ID.ToString()
                                                  }).ToList();

                List<SelectListItem> yoneticis = (from p in db.Personeller.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = p.AD + " " + p.SOYAD,
                                                     Value = p.ID.ToString()
                                                 }).ToList();

                ViewBag.departman = departmans;
                ViewBag.yonetici = yoneticis;
                return View();
            }
            var departman = db.Departmanlar.Find(personel.DepartmanID);
            var yonetici = db.Personeller.FirstOrDefault(x => x.ID == personel.YONETICI);
            if (yonetici!=null)
            {
                personel.YONETICIAD = yonetici.AD + " " + yonetici.SOYAD;
            }
            personel.Departman = departman;
            db.Personeller.Add(personel);
            db.SaveChanges();
            return RedirectToAction("Index","Personel");
        }
        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            var personelGetir = db.Personeller.Find(id);
            List<SelectListItem> departman = (from p in db.Departmanlar.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = p.DepartmanAd,
                                                  Value = p.ID.ToString()
                                              }).ToList();

            List<SelectListItem> yonetici = (from p in db.Personeller.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = p.AD + " " + p.SOYAD,
                                                 Value = p.ID.ToString()
                                             }).ToList();

            ViewBag.departman = departman;
            ViewBag.yonetici = yonetici;
            return View(personelGetir);
           
        }
        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGuncelle");
            }

            var personelGuncelle = db.Personeller.Find(personel.ID);
            personelGuncelle.AD = personel.AD;
            personelGuncelle.SOYAD = personel.SOYAD;
            personelGuncelle.TELEFON = personel.TELEFON;
            var departman = db.Departmanlar.Where(k => k.ID == personel.DepartmanID).FirstOrDefault();
            var yonetici = db.Personeller.Where(y => y.ID == personel.YONETICI).FirstOrDefault();
            personelGuncelle.Departman = departman;
            personelGuncelle.YONETICI = yonetici.YONETICI;
            personelGuncelle.YONETICIAD = yonetici.AD+" "+yonetici.SOYAD;
            personelGuncelle.DETAY = personel.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index","Personel");
        }

        public ActionResult PersonelSil(int id)
        {
            var silinecekPersonel = db.Personeller.Find(id);
            bool kontrol = false;
            foreach (var item in db.Personeller)
            {

                if (silinecekPersonel.ID == item.YONETICI)
                {
                    kontrol = true;
                    break;
                }

            }
            if (!kontrol)
            {
                db.Personeller.Remove(silinecekPersonel);
                db.SaveChanges();
                return RedirectToAction("Index", "Personel");
            }
            else
            {
                int sayfa = 1;
                ViewBag.hata = "Silmek İstediğiniz personel başka bir personelin yöneticisi olduğu için silme işlemi gerçekleşemez.";
                return View("Index", db.Personeller.ToList().ToPagedList(sayfa, 10));
            }
        }
    }
}
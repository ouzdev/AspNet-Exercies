using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefonRehberi.Models;
using TelefonRehberi.Models.EntityFramework;
using TelefonRehberi.Models.ViewModels;

namespace TelefonRehberi.Controllers
{

    public class AdminController : Controller
    {
        // Context nesnemi oluşturdum.

        DatabaseContext db = new DatabaseContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Admin user)
        {
            //Projede Login işlemleri ile ilgili bir ibare olmadığı için veritabanındaki tek kayıt üzerinden doğrulama yapıp panele yönlendirme sağlıyorum. 

            // Veritabanındaki kayıtı admin değişkenine atadım.
            var admin = db.SuperUser.Find(1);
            // admin değişkeni ile user nesnesindeki veriyi karşılaştırdım.
            if (user.KULLANICIADI == admin.KULLANICIADI && user.SIFRE == admin.SIFRE)
            {   // Eğer eşleşme başarılı ise Departmanın Index metoduna yönlendirme yaptım.
                return RedirectToAction("Index", "Departman");
            }
            //Eğer veritabanındaki kayıt ile user nesnesindeki veriler uyuşmuyorsa ViewBag ile sayfama hata mesajı gönderdim.

            ViewBag.hata = "Kullanıcı ad yada şifre hatalı";

            return View();

        }
        public ActionResult AdminIslemleri()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult AdminIslemleri(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var adminPassword = db.SuperUser.Find(1);
                if (user.Sifre == user.SifreTekrar)
                {
                    ViewBag.basarili = "Şifre değiştirme işleminiz başarılı.Lütfen sisteme tekrar giriş yapınız.";
                    adminPassword.SIFRE = user.Sifre;
                    db.SaveChanges();
                    return View("Login");
                }
                else
                {
                    ViewBag.hata = "Şifreniz Uyuşmuyor lütfen kontrol ediniz.";
                    return View();
                }

            }
            
            return View();
        }
           

    }
}
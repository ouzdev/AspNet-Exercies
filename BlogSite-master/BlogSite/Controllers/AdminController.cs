using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        BlogSiteDbEntities db = new BlogSiteDbEntities();
        public ActionResult Index()
        {
            db.Articles.ToList();
            return View();
        }
        public ActionResult BlogSettings()
        {
            var result = db.SiteSettings.Find(1);
            return View(result);
        }

        [HttpPost]
        public ActionResult BlogSettings(SiteSetting settings, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = Path.GetFileName(file.FileName);
                string path = Path.Combine(
                                       Server.MapPath("~/Images/Favicon/"), pic);
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                settings.FoviconUrl = path;
            }

            var update = db.SiteSettings.Find(1);

            update.Title = settings.Title;
            update.Description = settings.Description;
            update.Keywords = settings.Keywords;
            update.FoviconUrl = settings.FoviconUrl;
            update.GoogleAnalytics = settings.GoogleAnalytics;
            update.FacebookUrl = settings.FacebookUrl;
            update.LinkedinUrl = settings.LinkedinUrl;
            update.InstagramUrl = settings.InstagramUrl;
            update.FooterSignature = settings.FooterSignature;
            db.SaveChanges();
            return View("BlogSettings", update);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineKutuphanem.Models.Entity;
using OnlineKutuphanem.Models.ViewModels;

namespace OnlineKutuphanem.Controllers
{
    public class FrontPageController : Controller
    {
        // GET: FrontPage
        OnlineKutuphanemDBEntities db = new OnlineKutuphanemDBEntities();
        public ActionResult Index()
        {
            ViewModel model = new ViewModel();
            model.Kitaplar = db.Kitap.ToList();
            model.Hakkimizdas = db.Hakkimizda.ToList();
            return View(model);
        }
    }
}
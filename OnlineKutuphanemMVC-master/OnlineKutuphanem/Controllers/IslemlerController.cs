using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineKutuphanem.Models.Entity;

namespace OnlineKutuphanem.Controllers
{
    public class IslemlerController : Controller
    {
        // GET: Islemler
        OnlineKutuphanemDBEntities db = new OnlineKutuphanemDBEntities();
        public ActionResult Index()
        {
            var islemler = db.Hareket.Where(k => k.ISLEMDURUM == true).ToList();
            return View(islemler);
        }
    }
}
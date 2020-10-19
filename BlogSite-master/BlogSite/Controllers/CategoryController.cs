using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        BlogSiteDbEntities db = new BlogSiteDbEntities();
        public ActionResult CategoryList()
        {
            var result = db.Categories.ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList", "Category");
        }
        [HttpGet]
        public ActionResult CategoryUpdate(int? id)
        {
            return View(db.Categories.Find(id));
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            var result = db.Categories.Find(category.CategoryID);
            result.Name = category.Name;
            result.Description = category.Description;
            db.SaveChanges();
            return RedirectToAction("CategoryList", "Category");
        }

        public ActionResult CategoryDelete(int? id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
            return RedirectToAction("CategoryList", "Category");
        }
    }
}
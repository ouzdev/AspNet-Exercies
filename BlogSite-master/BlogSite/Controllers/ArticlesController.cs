using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        BlogSiteDbEntities db = new BlogSiteDbEntities();

        public ActionResult ArticleList()
        {
            var result = db.Articles.ToList();

            return View(result);
        }
        [HttpGet]
        public ActionResult AddArticle()
        {
            List<SelectListItem> category = (from i in db.Categories.ToList()

                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.CategoryID.ToString()
                                             }
                                            ).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public ActionResult AddArticle(Article article)
        {
            db.Articles.Add(article);
            return View();
        }

      public ActionResult PublishedArticles()
        {
            var result = db.Articles.Where(a => a.IsDraft == false).ToList();
            return View(result);
        }
        public ActionResult DraftArticles()
        {
            var result = db.Articles.Where(a => a.IsDraft == true).ToList();
            return View(result);
        }
    }
}
using BlogSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        BlogSiteDbEntities db = new BlogSiteDbEntities();
        public ActionResult UserList()
        {
            var result = db.Users.ToList();
            return View(result);
        }
        public ActionResult AddUser()
        {
            return View();
        }
    }
}
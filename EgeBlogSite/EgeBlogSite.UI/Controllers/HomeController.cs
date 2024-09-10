using EgeBlogSite.BLL.Repositories;
using EgeBlogSite.DAL;
using EgeBlogSite.Entity;
using EgeBlogSite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgeBlogSite.UI.Controllers
{

 
    public class HomeController : Controller
    {
        // GET: Home
        public HomeController()
        {
            Category c = new Category { Id = 1, Name = "Sağlık" };
            db.Categories.Add(c);

        }
            BlogSiteEntities db = new BlogSiteEntities();
        public ActionResult Welcome()
        {
            Category c = new Category { Id = 1, Name = "Sağlık" };
            db.Categories.Add(c);



            UserRepository UR = new UserRepository();
            List<User> Users = UR.GetAll();
            return View(Users);
        }
    }
}
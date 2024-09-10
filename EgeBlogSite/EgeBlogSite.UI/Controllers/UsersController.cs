using EgeBlogSite.BLL.Repositories;
using EgeBlogSite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgeBlogSite.UI.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        UserRepository UR = new UserRepository();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listele()
        {
            List<User> Users = UR.GetAll();
            return View(Users);
        }
        public ActionResult Ekle()
        {
            User yeniUser = new User();
            return View(yeniUser);

        }
        [HttpPost]
        public ActionResult Ekle(User u)
        {
            UR.Add(u);
            return RedirectToAction("Listele");

        }
        public ActionResult Delete(int id)
        {
            User u = UR.GetById(id);
            UR.Delete(u);
            return RedirectToAction("Listele"); 

          
        }
        public ActionResult Edit(int Id)
        {
            User user = UR.GetById(Id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            UR.Update(user);
            return RedirectToAction("Listele");
        }
    }
}
using EgeBlogSite.BLL.Repositories;
using EgeBlogSite.Entity;
using EgeBlogSite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgeBlogSite.UI.Controllers
{
   
    public class ArticlesController : Controller
    {
        // GET: Articles
        ArticleRepository AR = new ArticleRepository();
        CategoryRepository catrepo = new CategoryRepository();
        UserRepository userrepo = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listele()
        {
            List<Article> Articles = AR.GetAll();
            return View(Articles);
            
        }
        public ActionResult Ekle()
        {
            ViewModel model = new ViewModel();
            model.Article = new Article();
            model.Categories = catrepo.GetAll();
            model.Users = userrepo.GetAll();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(ViewModel vm)
        {
            
            AR.Add(vm.Article);
            return RedirectToAction("Listele");
            
        }
        public ActionResult Sil(int Id)
        {
            Article a = AR.GetById(Id);
            AR.Delete(a);
            return RedirectToAction("Listele");

        }
        public ActionResult Edit(int Id)
        {
            ViewModel a = new ViewModel();
            a.Article = AR.GetById(Id);
            a.Categories = catrepo.GetAll();
            a.Users = userrepo.GetAll();
            return View(a);
        }
        [HttpPost]
        public ActionResult Edit(ViewModel entity)
        {
            AR.Update(entity.Article);
            return RedirectToAction("Listele");

        }
    }
}

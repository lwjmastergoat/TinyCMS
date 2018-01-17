using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyRepo.Factories;
using TinyRepo.Models;

namespace TinyCMS.Controllers
{
    public class HomeController : Controller
    {
        FactoryArticle fa = new FactoryArticle();
        // GET: Home
        public ActionResult Index()
        {
            //List<ArticleUser> tempBox = new List<ArticleUser>();

            //tempBox = fa.GetAllJoin();

            //foreach(ArticleUser article in tempBox)
            //{
            //    if(article.Username == null)
            //    {
            //        article.Username = "HEST";
            //    }
            //}

            return View(fa.GetAllJoin());
        }

        public ActionResult Article(int ID)
        {
            return View(fa.GetJoin(ID));
        }
    }
}
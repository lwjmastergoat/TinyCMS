using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyRepo.Factories;
using TinyRepo.Models;
using TinyCMS.Helpers;
using System.IO;

namespace TinyCMS.Areas.CMS.Controllers
{
    public class ArticleController : Controller
    {
        int Admin = 3;
        int Editor = 2;
        int Writer = 1;

        FactoryArticle fa = new FactoryArticle();
        FileTools ft = new FileTools();
        public ActionResult Index()
        {
            if (Session["role"] == null || (int)Session["role"] < Writer)
            {
                return Redirect("/Login");
            }
            return View(fa.GetAllJoin());
        }

        public ActionResult AddNew()
        {
            if (Session["role"] == null || (int)Session["role"] < Writer)
            {
                return Redirect("/CMS");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(Articles input, HttpPostedFileBase Photo)
        {
            if (Session["role"] == null || (int)Session["role"] < Writer)
            {
                return Redirect("/CMS");
            }

            input.Date = DateTime.Now;
            input.UserID = (int)Session["id"];
            input.Image = null;

            if(Photo != null)
            {
                string imagePath = Request.PhysicalApplicationPath + "/ArticleImages/";
                input.Image = ft.ImageUpload(Photo, imagePath);
            }


            fa.Insert(input);

            return Redirect("/CMS/Article");
        }

        public ActionResult Delete(int ID)
        {
            if (Session["role"] == null || (int)Session["role"] < Editor)
            {
                return Redirect("/CMS/Article");
            }

            

            Articles article = fa.Get(ID);

            if(article.Image != null)
            {
                string imagePath = Request.PhysicalApplicationPath + "/ArticleImages/" + article.Image;
                
                if(System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            fa.Delete(ID);

            return Redirect("/CMS/Article");
        }

        public ActionResult Edit(int ID)
        {
            if (Session["role"] == null || (int)Session["role"] < Editor)
            {
                return Redirect("/CMS/Article");
            }

            return View(fa.Get(ID));
        }

        [HttpPost]
        public ActionResult Edit(Articles input, HttpPostedFileBase Photo)
        {
            if (Session["role"] == null || (int)Session["role"] < Editor)
            {
                return Redirect("/CMS/Article");
            }


            input.Image = null;
            input.Date = null;
            input.UserID = null;

            if(Photo != null)
            {
                Articles article = fa.Get(input.ID);

                if(article.Image != null)
                {
                    string imagePath = Request.PhysicalApplicationPath + "/ArticleImages/" + article.Image;

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    
                }
                string newImagePath = Request.PhysicalApplicationPath + "/ArticleImages/";
                input.Image = ft.ImageUpload(Photo, newImagePath);
            }

            fa.Update(input);
            

            return Redirect("/CMS/Article");
        }



    }
}
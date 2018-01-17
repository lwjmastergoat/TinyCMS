using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyRepo.Factories;
using TinyRepo.Models;

namespace TinyCMS.Areas.CMS.Controllers
{
    public class UserController : Controller
    {
        // GET: CMS/User
        int Admin = 3;
        int Editor = 2;
        int Writer = 1;

        FactoryUsers fu = new FactoryUsers();

        public ActionResult Index()
        {
            if (Session["role"] == null || (int)Session["role"] < Admin)
            {
                return Redirect("/CMS/User");
            }

            return View(fu.GetAll());
        }

        public ActionResult AddNew()
        {
            if (Session["role"] == null || (int)Session["role"] < Admin)
            {
                return Redirect("/CMS/User");
            }


            return View();
        }

        [HttpPost]

        public ActionResult AddNew(Users input)
        {
            if (Session["role"] == null || (int)Session["role"] < Admin)
            {
                return Redirect("/CMS/User");
            }

            fu.Insert(input);
            return Redirect("/CMS/User/");
        }
        public ActionResult Edit(int ID)
        {
            if (Session["role"] == null || (int)Session["role"] < Admin)
            {
                return Redirect("/CMS/User");
            }

            return View(fu.Get(ID));
        }

        [HttpPost]

        public ActionResult Edit(Users input)
        {
            if (Session["role"] == null || (int)Session["role"] < Admin)
            {
                return Redirect("/CMS/User");
            }

            if(input.ID == (int)Session["id"])
            {
                input.Role = null;
            }

            fu.Update(input);

            return Redirect("/CMS/User");
        }


        public ActionResult Delete(int ID)
        {
            if (Session["role"] == null || (int)Session["role"] < Admin || (int)Session["id"] == ID)
            {
                return Redirect("/CMS/User");
            }

            fu.Delete(ID);

            return Redirect("/CMS/User/");
        }



    }
}
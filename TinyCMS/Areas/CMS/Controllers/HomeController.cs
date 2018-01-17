using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyRepo.Factories;
using TinyRepo.Models;

namespace TinyCMS.Areas.CMS.Controllers
{
    public class HomeController : Controller
    {
        int Admin = 3;
        int Editor = 2;
        int Writer = 1;
        public ActionResult Index()
        {
            if (Session["role"] == null || (int)Session["role"] < Writer)
            {
                return Redirect("/Login");
            }

            return View();
        }
    }
}
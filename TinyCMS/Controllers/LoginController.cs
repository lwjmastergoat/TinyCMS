using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyRepo.Factories;
using TinyRepo.Models;

namespace TinyCMS.Controllers
{
    public class LoginController : Controller
    {
        FactoryUsers fu = new FactoryUsers();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            Users user = fu.Login(Username, Password);

            if(user.Username != null)
            {
                Session["id"] = user.ID;
                Session["role"] = user.Role;
                return Redirect("/CMS");
            }
            else
            {
                ViewBag.Msg ="<b>Forkert login</b>";
                return View();
            }            
        }

        public ActionResult Logout()
        {
            Session.Remove("id");
            Session.Remove("role");
            return Redirect("/Home/Index/");
        }
    }
}
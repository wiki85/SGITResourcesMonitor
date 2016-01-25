using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homer_MVC.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login(string username, string password)
        {
            try
            {
                if (username == "admin" && password == "admin")
                {
                    return RedirectToAction("Index", "Proyecto");
                }
                else
                {
                    return RedirectToAction("Index", "LandingPage");
                }
            }
            catch(Exception e)
            {
                return RedirectToAction("Index", "LandingPage");
            }
            
        }

    }
}

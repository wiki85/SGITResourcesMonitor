using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homer_MVC.Controllers
{
    public class ProyectoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetallesProyecto(string nombreProyecto)
        {
            ViewBag.nombreProyecto = nombreProyecto;
            return View();
        }
        public ActionResult VistaGridGlobal(string nombreProyecto)
        {
            ViewBag.nombreProyecto = nombreProyecto;
            return View();
        }
    }
}

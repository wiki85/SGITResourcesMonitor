using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homer_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetallesUsuario(string emailUsuario)
        {
            ViewBag.nombreProyecto = emailUsuario;
            return View();
        }
        public ActionResult Perfil(string emailUsuario)
        {
            ViewBag.nombreProyecto = emailUsuario;
            return View();
        }
    }
}

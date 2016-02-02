using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using BDAdministrator;
using Homer_MVC.Models;

namespace Homer_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdministrarUsuarios()
        {
            List<usuario> usuarios = new List<usuario>();
            List<string> columnas = new List<string>();

            if (ConnectionBD.conectarBD())
            {
                SqlDataReader mResultado = ConnectionBD.listarUsuarios();

                // Obtenemos la información en el siguiente orden: Nombre, Apellidos, Email, Telefono, Empresa, Privilegios. 
                while (mResultado.Read())
                {
                    usuario u = new usuario();

                    for (int i = 0; i < mResultado.FieldCount; i++)
                    {
                        switch (mResultado.GetName(i))
                        {
                            case "Nombre":
                                {
                                    u.Nombre = mResultado.GetValue(i).ToString();
                                    break;
                                }
                            case "Apellidos":
                                {
                                    u.Apellidos = mResultado.GetValue(i).ToString();
                                    break;
                                }
                            case "Email":
                                {
                                    u.Email = mResultado.GetValue(i).ToString();
                                    break;
                                }
                            case "Telefono":
                                {
                                    u.Telefono = mResultado.GetValue(i).ToString();
                                    break;
                                }
                            case "Empresa":
                                {
                                    u.Empresa = mResultado.GetValue(i).ToString();
                                    break;
                                }
                            case "Privilegios":
                                {
                                    u.Privilegios = mResultado.GetValue(i).ToString();
                                    break;
                                }
                            default:
                                {
                                    u.Nombre = "DESCONOCIDO";
                                    break;
                                }
                        }

                        if (columnas.Count < mResultado.FieldCount) 
                            columnas.Add(mResultado.GetName(i));
                    }

                    usuarios.Add(u);
                }

                ViewBag.Columnas = columnas;
                ViewBag.estadoConsulta = true;
            }
            else
                ViewBag.estadoConsulta = false;

            return View(usuarios);
        }
        public ActionResult Perfil(string emailUsuario)
        {
            try
            {
                if (ConnectionBD.conectarBD())
                {
                    SqlDataReader mResultado = ConnectionBD.obtenerUsuario(emailUsuario);

                    // Obtenemos la información en el siguiente orden: Nombre, Apellidos, Email, Telefono, Empresa. 
                    mResultado.Read();

                    ViewBag.nombreUsuario = mResultado.GetString(0);
                    ViewBag.apellidosUsuario = mResultado.GetString(1);
                    ViewBag.emailUsuario = mResultado.GetString(2);
                    ViewBag.telefonoUsuario = mResultado.GetString(3);
                    ViewBag.empresausUario = mResultado.GetString(4);

                    ViewBag.estadoConsulta = true;
                }
                else
                {
                    ViewBag.estadoConsulta = false;
                    ViewBag.mensajeError = "No se ha podido establecer la conexión a la base de datos";
                }

                return View();
            }
            catch (Exception e)
            {
                ViewBag.estadoConsulta = false;
                ViewBag.mensajeError = "No se ha podido establecer la conexión a la base de datos";
                return View();
            }
        }
    }
}

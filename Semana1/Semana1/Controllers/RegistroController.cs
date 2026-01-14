using Semana1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana1.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {
            Registro registro = new Registro();
            ViewBag.fechaRegistro = registro.fechaRegistro;
            return View();
        }

        public ActionResult MostrarRegistro()
        {
            Registro registro = new Registro();
            ViewBag.nombreCompleto = registro.nombreCompleto();
            return View(registro);
        }

        [HttpGet]
        public ActionResult GuardarRegistro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarRegistro(Registro registro)
        {
            return View();
        }
    }
}
using Semana2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana2.Controllers
{
    public class AlumnoController : Controller
    {

        List<Alumno> listaAlumnos = new List<Alumno>(){};
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            string nombreCompleto = alumno.nombreCompleto();
            AlumnoException.validarAlumno(alumno);
            ViewBag.NombreCompleto = "El nombre completo registrado es: "+ nombreCompleto;
            return View();
        }
    }
}
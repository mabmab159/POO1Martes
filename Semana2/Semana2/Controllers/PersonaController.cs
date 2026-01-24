using Semana2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana2.Controllers
{
    public class PersonaController : Controller
    {
        List<Persona> listaPersonas = new List<Persona>()
        {
            new Persona(70456789, "Juan", "Perez", "Soltero", new DateTime(1990, 5, 23)),
            new Persona(70987654, "Maria", "Gomez", "Casada", new DateTime(1985, 8, 15)),
            new Persona(71234567, "Luis", "Rodriguez", "Soltero", new DateTime(1992, 12, 3)),
            new Persona(72345678, "Ana", "Lopez", "Divorciada", new DateTime(1988, 3, 30)),
            new Persona(73456789, "Carlos", "Sanchez", "Casado", new DateTime(1979, 11, 20))
        };

        public ActionResult Index()
        {
            return View(listaPersonas);
        }
    }
}
using Semana2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana2.Controllers
{
    public class CursoController : Controller
    {
        
        List<Curso> listaCursos = new List<Curso>()
        {
            new Curso(){ id=1, nombre="Matemáticas", descripcion="Curso de Matemáticas Básicas", creditos=4 },
            new Curso(){ id=2, nombre="Física", descripcion="Curso de Física General", creditos=3 },
            new Curso(){ id=3, nombre="Química", descripcion="Curso de Química Orgánica", creditos=4 },
            new Curso(){ id=4, nombre="Historia", descripcion="Curso de Historia Universal", creditos=2 },
            new Curso(){ id=5, nombre="Literatura", descripcion="Curso de Literatura Clásica", creditos=3 }
        };

        public ActionResult Index()
        {
            return View(listaCursos);
        }

        public ActionResult Filtro(string nombre="")
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return View(new List<Curso>());
            }
            else
            {
                var cursosFiltrados = listaCursos.Where(e => e.nombre.StartsWith(nombre));
                return View(cursosFiltrados);
            }
        }
    }
}
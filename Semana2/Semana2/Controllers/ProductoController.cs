using Semana2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana2.Controllers
{
    public class ProductoController : Controller
    {
        static List<Producto> listaProductos = new List<Producto>();
        public ActionResult Index()
        {
            return View(listaProductos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            //Validar los campos
            if (!ModelState.IsValid)
            {
                return View();
            }
            listaProductos.Add(producto);
            ViewBag.Mensaje = "Producto registrado correctamente";
            return View();
        }
    }
}
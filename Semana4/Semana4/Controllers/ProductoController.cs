using Newtonsoft.Json;
using Semana4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana4.Controllers
{
    public class ProductoController : Controller
    {
        //JSON no es mas que un texto con formato estructurado
        static string productoJson = @"{
            'id': 1,
            'nombre': 'Laptop',
            'precio': 1500.00,
            'stock': 25
        }";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Deserializar(int indice = 0)
        {
            Producto p = JsonConvert.DeserializeObject<Producto>(productoJson);
            return View(p);
        }

        public ActionResult Serializar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Serializar(Producto producto)
        {
            string productoString = "";
            productoString = JsonConvert.SerializeObject(producto);

            ViewBag.productoString = productoString;
            return View(producto);
        }
    }
}
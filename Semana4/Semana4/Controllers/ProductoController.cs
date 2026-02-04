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
            'precios': 1500.00
        }";

        static string productoJsonLista = @"[
        {
            'id': 1,
            'nombre': 'Laptop',
            'precio': 1500.00,
            'stock': 10
        },
        {
            'id': 2,
            'nombre': 'Mouse',
            'precio': 20.00,
            'stock': 100
        },
        {
            'id': 3,
            'nombre': 'Teclado',
            'precio': 50.00,
            'stock': 50
        }]";

        //string -> List<Producto> | Deserializacion
        public ActionResult Index()
        {
            try
            {
                List<Producto> listaProductos = JsonConvert.DeserializeObject<List<Producto>>(productoJsonLista);
                return View(listaProductos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = " Ocurrio un error: " + ex.Message;
                return View(new List<Producto>());
            }

        }

        public ActionResult Deserializar(int indice = 0)
        {
            try
            {
                Producto p = JsonConvert.DeserializeObject<Producto>(productoJson);
                return View(p);
            }
            catch (Exception ex)
            {
                ViewBag.Error = " Ocurrio un error: " + ex.Message;
                return View(new Producto());
            }
        }

        public ActionResult Serializar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Serializar(Producto producto)
        {
            string productoString = "";
            try
            {
                productoString = JsonConvert.SerializeObject(producto);
                ViewBag.productoString = productoString;
                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.productoString = ex.Message;
                return View(new Producto());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        //1. Recibir el objeto Producto desde la vista Create
        //2. Deserializar el arreglo
        //3. Guardar el nuevo objeto en el arreglo
        //4. Volver a convertir de List<Producto> a JSON (string)
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            try
            {
                List<Producto> listaProductos = JsonConvert.DeserializeObject<List<Producto>>(productoJsonLista); //Posible falla
                listaProductos.Add(producto);
                productoJsonLista = JsonConvert.SerializeObject(listaProductos); //Posible falla
                ViewBag.Mensaje = "Producto agregado correctamente";
                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Producto());
            }

        }

        public ActionResult Details(int id = 0)
        {
            try
            {
                //Deserializar el arreglo
                List<Producto> listaProductos = JsonConvert.DeserializeObject<List<Producto>>(productoJsonLista);
                //Buscar el producto por id
                Producto producto = listaProductos.Find(p => p.id == id);
                return View(producto);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
                return View(new Producto());
            }
        }
    }
}
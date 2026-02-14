using Newtonsoft.Json;
using Semana5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana5.Controllers
{
    public class ProveedorController : Controller
    {
        static List<Proveedor> proveedores = new List<Proveedor>(); 
        string carpeta = "~/carpeta/";
        public ActionResult Index()
        {
            if (!System.IO.File.Exists($"{Server.MapPath(carpeta)}lista.json"))
            {
                return View(proveedores);
            }

            //Crear un FileStream para abrir | ubicar el archivo
            FileStream fileStream = new FileStream($"{Server.MapPath(carpeta)}lista.json", FileMode.Open);
            //Creo un StreamReader para leer el contenido del archivo
            StreamReader streamReader = new StreamReader(fileStream);
            proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(streamReader.ReadToEnd());

            //Cerrar el StreamWriter y el FileStream
            streamReader.Close();
            fileStream.Close();
            return View(proveedores);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string cadenaSerializada = JsonConvert.SerializeObject(proveedor);
            //Crear un FileStream para crear el archivo
            FileStream fileStream = new FileStream($"{Server.MapPath(carpeta)}lista.json", FileMode.Create);
            //Crear un StreamWriter para escribir en el archivo
            StreamWriter streamWriter = new StreamWriter(fileStream);
            //Escribir cadena serializada en el archivo
            streamWriter.Write(cadenaSerializada);

            //Cerrar el StreamWriter y el FileStream
            streamWriter.Close();
            fileStream.Close();

            ViewBag.mensaje = "Proveedor Registrado";

            return View(proveedor);
        }

        public ActionResult Create2()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create2(Proveedor proveedor)
        {
            //Paso 1. Validar el archivo
            if (!System.IO.File.Exists($"{Server.MapPath(carpeta)}lista.json"))
            {
                return View();
            }

            //Paso 2. Crear un FileStream para abrir | ubicar el archivo
            FileStream fileStream = new FileStream($"{Server.MapPath(carpeta)}lista.json", FileMode.Open);
            
            //Paso 3. Creo un StreamReader para leer el contenido del archivo
            StreamReader streamReader = new StreamReader(fileStream);
            
            //Paso 4. Deserializar el contenido del archivo y asignarlo a la variable proveedores
            proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(streamReader.ReadToEnd());

            //Paso5. Cerrar el StreamWriter y el FileStream
            streamReader.Close();
            fileStream.Close();

            //Paso 6. Agregar el nuevo proveedor a la lista de proveedores
            proveedores.Add(proveedor);

            //Paso 7. Serializar la lista de proveedores
            string cadenaSerializada = JsonConvert.SerializeObject(proveedores);

            //Paso 8. Crear un FileStream para crear el archivo
            fileStream = new FileStream($"{Server.MapPath(carpeta)}lista.json", FileMode.Create);

            //Paso 9. Crear un StreamWriter para escribir en el archivo
            StreamWriter streamWriter = new StreamWriter(fileStream);

            //Paso 10. Escribir cadena serializada en el archivo
            streamWriter.Write(cadenaSerializada);

            //Paso 11. Cerrar el StreamWriter y el FileStream
            streamWriter.Close();
            fileStream.Close();

            @ViewBag.mensaje = "Proveedor Registrado";

            return View(proveedor);
        }


        public ActionResult Details(int id=0)
        {
            FileStream fileStream = new FileStream($"{Server.MapPath(carpeta)}lista.json", FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);
            proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(reader.ReadToEnd());
            reader.Close();
            fileStream.Close();
            Proveedor proveedor = proveedores.Where(p => p.id == id).FirstOrDefault();
            return View(proveedor);
        }
    }
}
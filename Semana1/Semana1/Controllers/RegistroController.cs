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

        static List<Registro> listaRegistros = new List<Registro>() { new Registro(), new Registro()};

        Singleton singleton = Singleton.GetInstance(); //Crear la instancia
        Singleton singleton2 = Singleton.GetInstance(); //Reutiliza la instancia anterior

        // GET: Registro
        public ActionResult Index()
        {
            return View(listaRegistros);
        }

        public ActionResult MostrarRegistro()
        {
            Registro registro = new Registro();
            ViewBag.nombreCompleto = registro.nombreCompleto();
            return View(registro);
        }

        [HttpGet] // Crear la vista del formulario
        public ActionResult GuardarRegistro()
        {
            return View();
        }

        [HttpPost] //Esto sirve para cuando envie el formulario | Click en enviar o guardar
        public ActionResult GuardarRegistro(Registro registro)
        {
            listaRegistros.Add(registro);
            ViewBag.mensaje = "Registro guardado correctamente";
            return View();
        }

        public ActionResult Details(string codigoRegistro)
        {
            //Busque el codigo en la lista y luego lo muestre en la vista
            Registro registroEncontrado = listaRegistros.Find(e => e.codigo.Equals(codigoRegistro));
            //Retornar la vista con el registro encontrado
            return View(registroEncontrado);
        }

        public ActionResult Edit(string codigoRegistro)
        {
            //Busque el codigo en la lista y luego lo muestre en la vista
            Registro registroEncontrado = listaRegistros.Find(e => e.codigo.Equals(codigoRegistro));
            //Retornar la vista con el registro encontrado
            return View(registroEncontrado);
        }

        [HttpPost]
        public ActionResult Edit(Registro registro)
        {
            //Buscar el registro en la lista
            Registro registroEncontrado = listaRegistros.Find(e => e.codigo.Equals(registro.codigo));
            registroEncontrado.nombre = registro.nombre;
            registroEncontrado.apellido = registro.apellido;
            registroEncontrado.edad = registro.edad;
            ViewBag.mensaje = "Registro actualizado correctamente";
            return View(registroEncontrado);
        }

        public ActionResult Delete(string codigoRegistro)
        {
            //Busque el codigo en la lista y luego lo muestre en la vista
            Registro registroEncontrado = listaRegistros.Find(e => e.codigo.Equals(codigoRegistro));
            //Retornar la vista con el registro encontrado
            return View(registroEncontrado);
        }

        [HttpPost]
        public ActionResult Delete(Registro registro)
        {
            Registro registroEncontrado = listaRegistros.Find(e => e.codigo.Equals(registro.codigo));
            listaRegistros.Remove(registroEncontrado);
            return RedirectToAction("Index");
        }
    }
}
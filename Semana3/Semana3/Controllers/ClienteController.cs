using Semana3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Controllers
{
    public class ClienteController : Controller
    {
        static List<Cliente> listaClientes = new List<Cliente>()
        {
            new Cliente(){ dni="12345678", nombre="Juan", apellido="Perez", direccion="Calle Falsa 123", telefono="987654321"},
            new Cliente(){ dni="87654321", nombre="Maria", apellido="Gomez", direccion="Avenida Siempre Viva 742", telefono="123456789"},
            new Cliente(){ dni="11223344", nombre="Carlos", apellido="Lopez", direccion="Boulevard Central 456", telefono="456789123"},
        };

        public async Task<ActionResult> Index()
        {
            return View(await Task.Run(() => listaClientes));
        }

        public async Task<ActionResult> Filtro(string nombre ="")
        {
            if(string.IsNullOrEmpty(nombre))
            {
                return View(await Task.Run(() => new List<Cliente>()));
            }
            var listaFiltrada = await Task.Run(() => listaClientes.Where(e => e.nombre.StartsWith(nombre)));
            return View(listaFiltrada);
        }

        public async Task<ActionResult> Create()
        {
            return View(await Task.Run(() => new Cliente()));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            if(!ModelState.IsValid)
            {
                return View(await Task.Run(() => cliente));
            }
            listaClientes.Add(cliente);
            ViewBag.Mensaje = "Cliente creado correctamente";
            return View(await Task.Run(() => cliente));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Controllers
{
    public class ProcesosController : Controller
    {
        int CantidadDivisores (int n)
        {
            int cantidad = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                   cantidad++;
                }
            }
            return cantidad;
        }

        int SumaDivisores (int n)
        {
            int suma = 0;
            for(int i = 1; i <= n; i++)
            {
                if(n % i == 0)
                {
                    suma += i;
                }
            }
            return suma;
        }

        int SumaDigitos(int n)
        {
            int suma = 0;
            while (n > 0)
            {
                int digito = n % 10;
                suma += digito;
                n /= 10;
            }
            return suma;
        }

        async Task<string> ConsultarServicioExterno()
        {
            var client = new HttpClient();
            //Simular una llamada a un servicio externo con demora de 3 segundos
            await Task.Delay(3000);
            return "Respuesta del servicio externo";
        }

        public async Task<ActionResult> Operaciones(int n = 0)
        {
            ViewBag.cantidadDivisores = await Task.Run(() => CantidadDivisores(n));
            ViewBag.sumaDivisores = await Task.Run(() => SumaDivisores(n));
            ViewBag.sumaDigitos = await Task.Run(() => SumaDigitos(n));
            return View();
        }

        public async Task<ActionResult> OperacionesNoAsync(int n = 0)
        {
            var tiempo = Stopwatch.StartNew();

            ViewBag.cantidadDivisores = CantidadDivisores(n); // 100ms
            ViewBag.sumaDivisores = SumaDivisores(n); //100ms
            ViewBag.sumaDigitos =  SumaDigitos(n); //100ms
            ViewBag.servicio = await ConsultarServicioExterno(); //3000ms

            tiempo.Stop();
            ViewBag.tiempoTotal = tiempo.ElapsedMilliseconds;

            return View(); //Total: 3300ms
        }

        public async Task<ActionResult> OperacionesAsync(int n = 0)
        {
            var tiempo = Stopwatch.StartNew();

            ViewBag.cantidadDivisores = await Task.Run(() => CantidadDivisores(n)); //100ms
            ViewBag.sumaDivisores = await Task.Run(() => SumaDivisores(n)); //100ms
            ViewBag.sumaDigitos = await Task.Run(() => SumaDigitos(n)); //100ms
            ViewBag.servicio = await ConsultarServicioExterno(); //3000ms

            tiempo.Stop();
            ViewBag.tiempoTotal = tiempo.ElapsedMilliseconds;
            //Total: 3000ms
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
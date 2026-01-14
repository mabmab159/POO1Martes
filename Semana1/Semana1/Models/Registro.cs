using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana1.Models
{
    public class Registro
    {
        public string codigo {  get; set; }
        public DateTime fechaRegistro { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad {  get; set; }

        public Registro()
        {
            codigo = "241";
            fechaRegistro = DateTime.Today;
            nombre = "Miguel";
            apellido = "Berrio";
            edad = 0;
        }

        public string nombreCompleto()
        {
            return nombre+ " "+ apellido;
        }
    }
}
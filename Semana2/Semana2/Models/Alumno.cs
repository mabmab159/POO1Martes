using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public partial class Alumno
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string carrera { get; set; }
    }
}
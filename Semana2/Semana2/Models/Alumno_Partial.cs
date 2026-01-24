using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public partial class Alumno
    {
        public string nombreCompleto()
        {
            return nombre + " " + apellido;
        }
    }
}
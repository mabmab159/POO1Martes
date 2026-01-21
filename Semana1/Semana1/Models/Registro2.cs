using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana1.Models
{
    public class Registro2 : Registro, IRegistro1, IRegistro2
    {
        // Extends | Implements
        string IRegistro1.codigo(string variable)
        {
            return "Codigo desde IRegistro1: " + variable;
        }
    }
}
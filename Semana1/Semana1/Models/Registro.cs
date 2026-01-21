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

        public Registro(string codigo, string nombre, string apellido, int edad)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        public string nombreCompleto() // Firma del metodo = lo que retorna + nombre del metodo + parametros (tipos y el orden)
        {
            return nombre+ " "+ apellido;
        }

        public string nombreCompleto(string nombre) //string
        {
            return nombre + " " + apellido;
        }

        public string nombreCompleto(string variable, string apellido) //string, string
        {
            return variable + " " + apellido;
        }

        public string nombreCompleto(int variable1, string variable2) //int, string
        {
            return variable1 + " " + variable2;
        }

        public string nombreCompleto(string variable2, int variable1) //string, int
        {
            return variable1 + " " + variable2;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public class Persona : IPersona
    {
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string estadoCivil { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public Persona(int dni, string nombre, string apellido, string estadoCivil, DateTime fechaNacimiento)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.estadoCivil = estadoCivil;
            this.fechaNacimiento = fechaNacimiento;
        }

        public string nombreCompleto()
        {
            return nombre + " " + apellido;
        }

        public int edad()
        {
            return DateTime.Now.Year - fechaNacimiento.Year;
        }
    }
}
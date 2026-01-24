using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public class AlumnoException: Exception
    {
        public AlumnoException()
        {
        }

        public AlumnoException(string message): base(message)
        {
        }

        public AlumnoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public static void levantarError() //Persiste en la memoria | Se autogenera
        {
            throw new AlumnoException("Error en la operación del alumno");
        }

        public static void validarAlumno(Alumno alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.nombre) || string.IsNullOrWhiteSpace(alumno.apellido))
            {
                levantarError();
            }
        }
    }
}
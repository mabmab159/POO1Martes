using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana1.Models
{
    public class Singleton
    {
        private static Singleton singleton;
        private Singleton() { }

        //Este metodo se encarga de la gestion de la instancia unica
        public static Singleton GetInstance()
        {
            if(singleton == null)
            {
                singleton = new Singleton();
            }
            return singleton;
        }

        public string Mensaje()
        {
            return "Hola desde el patron Singleton";
        }
    }
}
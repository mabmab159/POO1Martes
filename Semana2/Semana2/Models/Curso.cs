using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public class Curso
    {
        [Key] public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int creditos { get; set; }
    }
}
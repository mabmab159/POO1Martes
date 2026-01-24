using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Semana2.Models
{
    public class Producto
    {
        public int id { get; set; }
        [DisplayName("Nombre")] public string nombre { get; set; }
        [DisplayName("Categoria")] public string categoria { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
    }

    public enum categoria
    {
        Electronica,
        Ropa,
        Hogar,
        Deportes,
        Alimentos
    }
}
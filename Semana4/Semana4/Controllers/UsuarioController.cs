using Semana4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana4.Controllers
{
    public class UsuarioController : Controller
    {
        
        //Nunca: Se recomienda tener las cadenas de conexion o claves etc etc en el codigo fuente.
        //string SQLConnectionString = "Data Source=localhost;Initial Catalog=Semana4;Integrated Security=True";

        IEnumerable<Usuario> obtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            //SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Semana4;Integrated Security=True");

            //Especifico mi cadena de conexion
            SqlConnection connectionConfig = new SqlConnection(ConfigurationManager.ConnectionStrings["baseDatos"].ConnectionString);

            //Abro la cadena de conexion
            connectionConfig.Open();

            //Creo un comando SQL
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuarios", connectionConfig);

            //Ejecuto el comando SQL y obtengo un DataReader
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Usuario usuarioAux = new Usuario
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Email = reader.GetString(2),
                    FechaRegistro = reader.GetDateTime(3)
                };
                usuarios.Add(usuarioAux);
            }

            return usuarios;
        }


        public ActionResult Index()
        {
            return View(obtenerUsuarios());
        }
    }
}
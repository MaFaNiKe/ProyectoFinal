using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace Entidades
{
    public class ConexionBD
    {
        // Método para obtener la conexión a la base de datos
        public static MySqlConnection ObtenerConexion()
        {
            // Cadena de conexión desde el archivo de configuración (App.config)
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Creamos la conexión utilizando la cadena de conexión
            MySqlConnection conexion = new MySqlConnection(connectionString);

            return conexion;  // Devolvemos la conexión
        }
    }
}

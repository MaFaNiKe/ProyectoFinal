using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Entidades
{
    public class Canal
    {
        public int IdCanal { get; set; }
        public string NombreCanal { get; set; }

        // Constructor
        public Canal(int idCanal, string nombreCanal)
        {
            IdCanal = idCanal;
            NombreCanal = nombreCanal;
        }

        // Métodos para interactuar con la base de datos
        public static List<Canal> ObtenerTodosLosCanales()
        {
            List<Canal> canales = new List<Canal>();
            using (MySqlConnection con = ConexionBD.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM canal";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Canal canal = new Canal(
                        Convert.ToInt32(reader["ID_CANAL"]),
                        reader["NOMBRE"].ToString()
                    );
                    canales.Add(canal);
                }
            }
            return canales;
        }

        public static Canal ObtenerCanalPorId(int idCanal)
        {
            Canal canal = null;
            using (MySqlConnection con = ConexionBD.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM canal WHERE ID_CANAL = @idCanal";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idCanal", idCanal);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    canal = new Canal(
                        Convert.ToInt32(reader["ID_CANAL"]),
                        reader["NOMBRE"].ToString()
                    );
                }
            }
            return canal;
        }

        public static bool CrearCanal(string nombreCanal)
        {
            bool exito = false;
            using (MySqlConnection con = ConexionBD.ObtenerConexion())
            {
                con.Open();
                string query = "INSERT INTO canal (NOMBRE_CANAL) VALUES (@nombreCanal)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nombreCanal", nombreCanal);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    exito = true;
                }
            }
            return exito;
        }

        public static bool EliminarCanal(int idCanal)
        {
            bool exito = false;
            using (MySqlConnection con = ConexionBD.ObtenerConexion())
            {
                con.Open();
                string query = "DELETE FROM canal WHERE ID_CANAL = @idCanal";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idCanal", idCanal);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    exito = true;
                }
            }
            return exito;
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using Entidades;

namespace DAL
{
    public class TemaDAL
    {
        private readonly string connectionString;

        public TemaDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Tema> ObtenerTemas()
        {
            List<Tema> temas = new List<Tema>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_tema, tema FROM tema";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tema tema = new Tema
                        {
                            IdTema = reader.GetInt32("id_tema"),
                            NombreTema = reader.GetString("tema")
                        };
                        temas.Add(tema);
                    }
                }
            }
            return temas;
        }

        public void InsertarTema(Tema tema)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO tema (tema) VALUES (@tema)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@tema", tema.NombreTema);
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarTema(Tema tema)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE tema SET tema = @tema WHERE id_tema = @id_tema";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@tema", tema.NombreTema);
                cmd.Parameters.AddWithValue("@id_tema", tema.IdTema);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarTema(int idTema)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM tema WHERE id_tema = @id_tema";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id_tema", idTema);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

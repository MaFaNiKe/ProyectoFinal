using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;  

namespace DAL
{
    public class EvPostDAL
    {
        private readonly string connectionString;

        // Constructor sin parámetros
        public EvPostDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // insertar una relación evento-post
        public void InsertarEvPost(EvPost evPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO ev_post (id_post, id_evento) VALUES (@idPost, @idEvento)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPost", evPost.IdPost);
                command.Parameters.AddWithValue("@idEvento", evPost.IdEvento);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // eliminar una relación evento-post
        public void EliminarEvPost(int idPost, int idEvento)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM ev_post WHERE id_post = @idPost AND id_evento = @idEvento";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPost", idPost);
                command.Parameters.AddWithValue("@idEvento", idEvento);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // obtener todas las relaciones evento-post
        public List<EvPost> ObtenerEvPosts()
        {
            var listaEvPosts = new List<EvPost>();

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM ev_post";
                var command = new MySqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var evPost = new EvPost
                        {
                            IdPost = reader.GetInt32("id_post"),
                            IdEvento = reader.GetInt32("id_evento")
                        };

                        listaEvPosts.Add(evPost);
                    }
                }
            }

            return listaEvPosts;
        }
    }
}

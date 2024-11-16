using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;

namespace DAL
{
    public class UpvoteUpDAL
    {
        private readonly string connectionString;

        public UpvoteUpDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void InsertarUpvote(UpvoteUp upvote)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "INSERT INTO upvote_up (id_perfil, id_post) VALUES (@IdPerfil, @IdPost)";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdPerfil", upvote.IdPerfil);
                command.Parameters.AddWithValue("@IdPost", upvote.IdPost);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarUpvote(int idPerfil, int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "DELETE FROM upvote_up WHERE id_perfil = @IdPerfil AND id_post = @IdPost";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                command.Parameters.AddWithValue("@IdPost", idPost);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<UpvoteUp> ObtenerUpvotesPorIdPost(int idPost)
        {
            var upvotes = new List<UpvoteUp>();
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM upvote_up WHERE id_post = @IdPost";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdPost", idPost);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var upvote = new UpvoteUp
                        {
                            IdPerfil = reader.GetInt32("id_perfil"),
                            IdPost = reader.GetInt32("id_post")
                        };
                        upvotes.Add(upvote);
                    }
                }
            }
            return upvotes;
        }
    }
}

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration; 
using Entidades;

namespace DAL
{
    public class UpvoteUtDAL
    {
        private readonly string connectionString;

        public UpvoteUtDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void InsertarUpvote(UpvoteUt upvote)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "INSERT INTO upvote_ut (id_perfil, id_tema) VALUES (@IdPerfil, @IdTema)";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdPerfil", upvote.IdPerfil);
                command.Parameters.AddWithValue("@IdTema", upvote.IdTema);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarUpvote(int idPerfil, int idTema)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "DELETE FROM upvote_ut WHERE id_perfil = @IdPerfil AND id_tema = @IdTema";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                command.Parameters.AddWithValue("@IdTema", idTema);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<UpvoteUt> ObtenerUpvotesPorTema(int idTema)
        {
            var upvotes = new List<UpvoteUt>();

            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM upvote_ut WHERE id_tema = @IdTema";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdTema", idTema);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var upvote = new UpvoteUt
                        {
                            IdPerfil = reader.GetInt32("id_perfil"),
                            IdTema = reader.GetInt32("id_tema")
                        };
                        upvotes.Add(upvote);
                    }
                }
            }

            return upvotes;
        }
    }
}

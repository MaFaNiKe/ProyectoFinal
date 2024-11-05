using System;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration; 

namespace DAL
{
    public class PostLinkDAL
    {
        private readonly string connectionString;


        public PostLinkDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AgregarPostLink(PostLink postLink)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO post_link (id_post, link) VALUES (@IdPost, @Link)", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", postLink.IdPost);
                    command.Parameters.AddWithValue("@Link", postLink.Url);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPostLink(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM post_link WHERE id_post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    command.ExecuteNonQuery();
                }
            }
        }

        public PostLink ObtenerPostLinkPorId(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM post_link WHERE id_post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PostLink
                            {
                                IdLink = reader.GetInt32("id_post"),
                                IdPost = reader.GetInt32("id_post"),
                                Url = reader.GetString("link")
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}

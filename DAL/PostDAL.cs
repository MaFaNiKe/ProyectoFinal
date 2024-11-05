using System;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration; 

namespace DAL
{
    public class PostDAL
    {
        private readonly string connectionString;

        public PostDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AgregarPost(Post post)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO post (id_post, id_perfil, fecha) VALUES (@IdPost, @IdPerfil, @Fecha)", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", post.IdPost);
                    command.Parameters.AddWithValue("@IdPerfil", post.IdPerfil);
                    command.Parameters.AddWithValue("@Fecha", post.Fecha);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPost(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM post WHERE id_post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Post ObtenerPostPorId(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM post WHERE id_post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Post
                            {
                                IdPost = reader.GetInt32("id_post"),
                                IdPerfil = reader.GetInt32("id_perfil"),
                                Fecha = reader.GetDateTime("fecha"),
                                ContenidoTexto = reader.GetString("contenido_texto"),
                                ContenidoImagen = reader.GetString("contenido_imagen"),
                                ContenidoLink = reader.GetString("contenido_link")
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}

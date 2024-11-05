using System;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;  

namespace DAL
{
    public class PostImagenDAL
    {
        private readonly string connectionString;

        public PostImagenDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AgregarPostImagen(PostImagen postImagen)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO post_imagen (id_post, imagen) VALUES (@IdPost, @UrlImagen)", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", postImagen.IdPost);
                    command.Parameters.AddWithValue("@UrlImagen", postImagen.UrlImagen);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPostImagen(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM post_imagen WHERE id_post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    command.ExecuteNonQuery();
                }
            }
        }

        public PostImagen ObtenerPostImagenPorId(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM post_imagen WHERE id_post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PostImagen
                            {
                                IdImagen = reader.GetInt32("id_post"),
                                IdPost = reader.GetInt32("id_post"),
                                UrlImagen = reader.GetString("imagen"),
                                FechaSubida = reader.GetDateTime("fecha_subida")
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}

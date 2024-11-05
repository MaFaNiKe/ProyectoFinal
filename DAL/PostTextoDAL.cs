using System;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration; 

namespace DAL
{
    public class PostTextoDAL
    {
        private readonly string connectionString;


        public PostTextoDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AgregarPostTexto(PostTexto postTexto)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO post_texto (id_post, texto) VALUES (@IdPost, @Texto)", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", postTexto.IdPost);
                    command.Parameters.AddWithValue("@Texto", postTexto.ContenidoTexto);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPostTexto(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM post_texto WHERE id_post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    command.ExecuteNonQuery();
                }
            }
        }

        public PostTexto ObtenerPostTextoPorId(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM post_texto WHERE id_post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PostTexto
                            {
                                IdTexto = reader.GetInt32("id_post"),
                                IdPost = reader.GetInt32("id_post"),
                                ContenidoTexto = reader.GetString("texto"),
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

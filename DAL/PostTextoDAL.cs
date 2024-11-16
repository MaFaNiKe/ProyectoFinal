using System;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;
using System.Collections.Generic;

namespace DAL
{
    public class PostTextoDAL
    {
        private readonly string connectionString;

        public PostTextoDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AgregarPostTexto(PostTexto postTexto)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO post_texto (ID_POST, TEXTO) VALUES (@IdPost, @Texto)", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", postTexto.IdPost);
                    command.Parameters.AddWithValue("@Texto", postTexto.textoTexto);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarPostTexto(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM post_texto WHERE ID_POST = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Corrección: Obtener un solo PostTexto por su Id
        public PostTexto ObtenerPostTextoPorId(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM post_texto WHERE ID_POST = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Si se encuentra un resultado
                        {
                            return new PostTexto
                            {
                                IdPost = reader.GetInt32("ID_POST"),
                                textoTexto = reader.GetString("TEXTO")
                            };
                        }
                    }
                }
            }
            return null; // Si no se encuentra el PostTexto
        }

        public List<PostTexto> ObtenerPostTextosPorIdPost(int idPost)
        {
            var postTextos = new List<PostTexto>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM post_texto WHERE ID_POST = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var postTexto = new PostTexto
                            {
                                IdPost = reader.GetInt32("ID_POST"),
                                textoTexto = reader.GetString("TEXTO")
                            };
                            postTextos.Add(postTexto);
                        }
                    }
                }
            }
            return postTextos;
        }
    }
}

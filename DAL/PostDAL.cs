using System;
using System.Collections.Generic;
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
            // Obtener cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // Método para agregar un nuevo post
        public int AgregarPost(Post post)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var command = new MySqlCommand(
                    "INSERT INTO post (id_Perfil, Fecha, Texto, Likes) VALUES (@IdPerfil, @Fecha, @Texto, @Likes); SELECT LAST_INSERT_ID();",
                    connection);
                command.Parameters.AddWithValue("@IdPerfil", post.IdPerfil);
                command.Parameters.AddWithValue("@Fecha", post.Fecha);
                command.Parameters.AddWithValue("@Texto", post.Texto);
                command.Parameters.AddWithValue("@Likes", post.Likes);

                post.IdPost = Convert.ToInt32(command.ExecuteScalar());
                return post.IdPost;
            }
        }

        // Método para eliminar un post por ID
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

        // Método para obtener un post por ID
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
                            var post = new Post
                            {
                                IdPost = reader.GetInt32("id_post"),
                                IdPerfil = reader.GetInt32("id_perfil"),
                                Fecha = reader.GetDateTime("fecha"),
                                Texto = reader.GetString("texto"),  // Obtener el texto del post
                                Likes = reader.GetInt32("likes")    // Obtener el contador de likes
                            };

                            // Obtener likes de usuarios
                            post.LikesUsuarios = ObtenerLikesPorPost(idPost);

                            return post;
                        }
                    }
                }
            }
            return null;
        }

        // Método para obtener todos los posts
        public List<Post> ObtenerTodosLosPosts()
        {
            var posts = new List<Post>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(
                    "SELECT p.*, u.nombre AS NombreUsuario FROM post p JOIN usuario u ON p.id_Perfil = u.id_Perfil",
                    connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var post = new Post
                            {
                                IdPost = reader.GetInt32("id_post"),
                                IdPerfil = reader.GetInt32("id_perfil"),
                                Fecha = reader.GetDateTime("fecha"),
                                Texto = reader.GetString("texto"),  // Obtener el texto del post
                                Likes = reader.GetInt32("likes"),    // Obtener el contador de likes
                                NombreUsuario = reader.GetString("NombreUsuario"), // Obtener el nombre del usuario
                                LikesUsuarios = ObtenerLikesPorPost(reader.GetInt32("id_post")) // Obtener likes asociados
                            };
                            posts.Add(post);
                        }
                    }
                }
            }
            return posts;
        }

        // Método para actualizar el contador de likes de un post
        public void ActualizarLikes(int idPost, int nuevoLikes)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE post SET likes = @Likes WHERE id_post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@Likes", nuevoLikes);
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para agregar un like a un post
        public void AgregarLike(int idPost, int idPerfil)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO likes (id_Post, id_Perfil) VALUES (@IdPost, @IdPerfil)", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                    command.ExecuteNonQuery();
                }
            }

            // Actualizar el contador de likes del post
            var post = ObtenerPostPorId(idPost);
            if (post != null)
            {
                ActualizarLikes(idPost, post.Likes + 1);
            }
        }

        // Método para obtener los IDs de usuarios que dieron like a un post
        private List<int> ObtenerLikesPorPost(int idPost)
        {
            var likesUsuarios = new List<int>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT id_Perfil FROM likes WHERE id_Post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            likesUsuarios.Add(reader.GetInt32("id_Perfil"));
                        }
                    }
                }
            }
            return likesUsuarios;
        }
    }
}

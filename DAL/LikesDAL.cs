using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;

namespace DAL
{
    public class LikesDAL
    {
        private readonly string connectionString;

        public LikesDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // Método para verificar si un perfil ya dio like a un post
        public bool PerfilYaDioLike(int idPerfil, int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT COUNT(*) FROM likes WHERE id_Perfil = @IdPerfil AND id_Post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        // Método para agregar un like
        public void AgregarLike(Likes like)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO likes (id_Post, id_Perfil) VALUES (@IdPost, @IdPerfil)", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", like.IdPost);
                    command.Parameters.AddWithValue("@IdPerfil", like.IdPerfil);
                    command.ExecuteNonQuery();
                }
            }

            // Actualizar el contador de likes del post
            var postDAL = new PostDAL();
            var post = postDAL.ObtenerPostPorId(like.IdPost);
            if (post != null)
            {
                postDAL.ActualizarLikes(like.IdPost, post.Likes + 1);
            }
        }

        // Método para obtener la cantidad de likes de un post
        public int ObtenerCantidadLikes(int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT COUNT(*) FROM likes WHERE id_Post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // Método para quitar un like
        public void QuitarLike(int idPerfil, int idPost)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM likes WHERE id_Perfil = @IdPerfil AND id_Post = @IdPost", connection))
                {
                    command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                    command.Parameters.AddWithValue("@IdPost", idPost);
                    command.ExecuteNonQuery();
                }
            }

            // Actualizar el contador de likes del post
            var postDAL = new PostDAL();
            var post = postDAL.ObtenerPostPorId(idPost);
            if (post != null)
            {
                postDAL.ActualizarLikes(idPost, post.Likes - 1);
            }
        }
    }
}

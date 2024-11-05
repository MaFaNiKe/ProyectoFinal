using System;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration; 

namespace DAL
{
    public class MensajeLinkDAL
    {
        private readonly string connectionString;

        public MensajeLinkDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AgregarMensajeLink(MensajeLink mensajeLink)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO mensaje_link (id_mensaje, link) VALUES (@IdMensaje, @Link)", connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", mensajeLink.IdMensaje);
                    command.Parameters.AddWithValue("@Link", mensajeLink.Link);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarMensajeLink(int idMensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM mensaje_link WHERE id_mensaje = @IdMensaje", connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.ExecuteNonQuery();
                }
            }
        }

        public MensajeLink ObtenerMensajeLinkPorId(int idMensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM mensaje_link WHERE id_mensaje = @IdMensaje", connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MensajeLink
                            {
                                IdMensaje = reader.GetInt32("id_mensaje"),
                                Link = reader.GetString("link")
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}

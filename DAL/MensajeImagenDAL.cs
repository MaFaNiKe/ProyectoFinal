using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration; 

namespace DAL
{
    public class MensajeImagenDAL
    {
        private readonly string connectionString;


        public MensajeImagenDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AgregarMensajeImagen(MensajeImagen mensajeImagen)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO mensaje_imagen (id_mensaje, imagen) VALUES (@IdMensaje, @Imagen)", connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", mensajeImagen.IdMensaje);
                    command.Parameters.AddWithValue("@Imagen", mensajeImagen.Imagen);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarMensajeImagen(int idMensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM mensaje_imagen WHERE id_mensaje = @IdMensaje", connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.ExecuteNonQuery();
                }
            }
        }

        public MensajeImagen ObtenerMensajeImagenPorId(int idMensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM mensaje_imagen WHERE id_mensaje = @IdMensaje", connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MensajeImagen
                            {
                                IdMensaje = reader.GetInt32("id_mensaje"),
                                Imagen = reader.GetString("imagen")
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}

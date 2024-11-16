using System;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;

namespace DAL
{
    public class MensajeTextoDAL
    {
        private readonly string connectionString;

        public MensajeTextoDAL()
        {
            // Cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // Método para agregar un mensaje de texto
        public void AgregarMensajeTexto(MensajeTexto mensajeTexto)
        {
            string query = "INSERT INTO MENSAJE_TEXTO (ID_MENSAJE, TEXTO) VALUES (@idMensaje, @texto)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idMensaje", mensajeTexto.IdMensaje);
                        cmd.Parameters.AddWithValue("@texto", mensajeTexto.Texto);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el mensaje de texto: " + ex.Message);
                }
            }
        }

        // Método para obtener un mensaje de texto por su ID (ahora devuelve un objeto MensajeTexto)
        public MensajeTexto ObtenerMensajeTextoPorId(int idMensaje)
        {
            MensajeTexto mensajeTexto = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT ID_MENSAJE, TEXTO FROM MENSAJE_TEXTO WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mensajeTexto = new MensajeTexto
                            {
                                IdMensaje = reader.GetInt32("ID_MENSAJE"),
                                Texto = reader.GetString("TEXTO")
                            };
                        }
                    }
                }
            }

            return mensajeTexto;
        }

        // Método para actualizar un mensaje de texto
        public void ActualizarMensajeTexto(int idMensaje, string nuevoTexto)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE MENSAJE_TEXTO SET TEXTO = @Texto WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.Parameters.AddWithValue("@Texto", nuevoTexto);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar un mensaje de texto
        public void EliminarMensajeTexto(int idMensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM MENSAJE_TEXTO WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

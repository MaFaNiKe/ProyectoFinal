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

        public void AgregarMensajeTexto(MensajeTexto mensajeTexto)
        {
            // Validación de datos
            if (mensajeTexto == null)
            {
                throw new ArgumentNullException(nameof(mensajeTexto), "El mensaje de texto no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(mensajeTexto.Texto))
            {
                throw new ArgumentException("El texto no puede estar vacío.", nameof(mensajeTexto.Texto));
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("INSERT INTO mensaje_texto (id_mensaje, texto) VALUES (@IdMensaje, @Texto)", connection))
                    {
                        command.Parameters.AddWithValue("@IdMensaje", mensajeTexto.IdMensaje);
                        command.Parameters.AddWithValue("@Texto", mensajeTexto.Texto);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores de la base de datos
                Console.WriteLine($"Error al agregar mensaje de texto: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        public void EliminarMensajeTexto(int idMensaje)
        {
            if (idMensaje <= 0)
            {
                throw new ArgumentException("El ID del mensaje debe ser mayor que cero.", nameof(idMensaje));
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("DELETE FROM mensaje_texto WHERE id_mensaje = @IdMensaje", connection))
                    {
                        command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores de la base de datos
                Console.WriteLine($"Error al eliminar mensaje de texto: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        public MensajeTexto ObtenerMensajeTextoPorId(int idMensaje)
        {
            if (idMensaje <= 0)
            {
                throw new ArgumentException("El ID del mensaje debe ser mayor que cero.", nameof(idMensaje));
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("SELECT * FROM mensaje_texto WHERE id_mensaje = @IdMensaje", connection))
                    {
                        command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new MensajeTexto
                                {
                                    IdMensaje = reader.GetInt32("id_mensaje"),
                                    Texto = reader.GetString("texto")
                                };
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores de la base de datos
                Console.WriteLine($"Error al obtener mensaje de texto: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }

            return null; // Devuelve null si no se encuentra el mensaje
        }
    }
}

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;

namespace DAL
{
    public class ChatDAL
    {
        private readonly string connectionString;

        public ChatDAL()
        {
            // Cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insertar(Chat chat)
        {
            // Validación de datos
            if (chat == null)
            {
                throw new ArgumentNullException(nameof(chat), "El chat no puede ser nulo.");
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var query = "INSERT INTO chat (id_chat, chat_grupal) VALUES (@IdChat, @ChatGrupal)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdChat", chat.IdChat);
                        command.Parameters.AddWithValue("@ChatGrupal", chat.ChatGrupal);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores de la base de datos
                Console.WriteLine($"Error al insertar chat: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        public Chat ObtenerPorId(int idChat)
        {
            if (idChat <= 0)
            {
                throw new ArgumentException("El ID del chat debe ser mayor que cero.", nameof(idChat));
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var query = "SELECT * FROM chat WHERE id_chat = @IdChat";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdChat", idChat);

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Chat
                                {
                                    IdChat = reader.GetInt32("id_chat"),
                                    ChatGrupal = reader.GetBoolean("chat_grupal")
                                };
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores de la base de datos
                Console.WriteLine($"Error al obtener chat por ID: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }

            return null; // Devuelve null si no se encuentra el chat
        }

        public void Actualizar(Chat chat)
        {
            // Validación de datos
            if (chat == null)
            {
                throw new ArgumentNullException(nameof(chat), "El chat no puede ser nulo.");
            }

            if (chat.IdChat <= 0)
            {
                throw new ArgumentException("El ID del chat debe ser mayor que cero.", nameof(chat.IdChat));
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var query = "UPDATE chat SET chat_grupal = @ChatGrupal WHERE id_chat = @IdChat";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdChat", chat.IdChat);
                        command.Parameters.AddWithValue("@ChatGrupal", chat.ChatGrupal);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores de la base de datos
                Console.WriteLine($"Error al actualizar chat: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        public void Eliminar(int idChat)
        {
            if (idChat <= 0)
            {
                throw new ArgumentException("El ID del chat debe ser mayor que cero.", nameof(idChat));
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var query = "DELETE FROM chat WHERE id_chat = @IdChat";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdChat", idChat);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores de la base de datos
                Console.WriteLine($"Error al eliminar chat: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        public List<Chat> ObtenerTodos()
        {
            var chats = new List<Chat>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    var query = "SELECT * FROM chat";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                chats.Add(new Chat
                                {
                                    IdChat = reader.GetInt32("id_chat"),
                                    ChatGrupal = reader.GetBoolean("chat_grupal")
                                });
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo de errores de la base de datos
                Console.WriteLine($"Error al obtener todos los chats: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros errores
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }

            return chats;
        }
    }
}

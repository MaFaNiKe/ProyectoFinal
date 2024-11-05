using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;

namespace DAL
{
    public class MensajeDAL
    {
        private readonly string connectionString;

        public MensajeDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void AgregarMensaje(Mensaje mensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO MENSAJE (ID_MENSAJE, ID_CHAT, id_Perfil_Envia, id_Perfil_Recibe, FECHA_HORA) VALUES (@IdMensaje, @IdChat, @IdPerfilEnvia, @IdPerfilRecibe, @FechaHora)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", mensaje.IdMensaje);
                    command.Parameters.AddWithValue("@IdChat", mensaje.IdChat);
                    command.Parameters.AddWithValue("@IdPerfilEnvia", mensaje.IdPerfilEnvia);
                    command.Parameters.AddWithValue("@IdPerfilRecibe", mensaje.IdPerfilRecibe);
                    command.Parameters.AddWithValue("@FechaHora", mensaje.FechaHora);
                    command.ExecuteNonQuery();
                }

                // Agregar texto, imagen o enlace según el tipo de mensaje
                switch (mensaje.Tipo)
                {
                    case Mensaje.MensajeTipo.Texto:
                        AgregarTexto(mensaje.IdMensaje, mensaje.Texto);
                        break;
                    case Mensaje.MensajeTipo.Imagen:
                        AgregarImagen(mensaje.IdMensaje, mensaje.Imagen);
                        break;
                    case Mensaje.MensajeTipo.Link:
                        AgregarLink(mensaje.IdMensaje, mensaje.Link);
                        break;
                }
            }
        }

        // Método para agregar un mensaje de texto
        private void AgregarTexto(int idMensaje, string texto)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO MENSAJE_TEXTO (ID_MENSAJE, TEXTO) VALUES (@IdMensaje, @Texto)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.Parameters.AddWithValue("@Texto", texto);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para agregar un mensaje de imagen
        private void AgregarImagen(int idMensaje, string imagen)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO MENSAJE_IMAGEN (ID_MENSAJE, IMAGEN) VALUES (@IdMensaje, @Imagen)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.Parameters.AddWithValue("@Imagen", imagen);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para agregar un mensaje de enlace
        private void AgregarLink(int idMensaje, string link)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO MENSAJE_LINK (ID_MENSAJE, LINK) VALUES (@IdMensaje, @Link)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.Parameters.AddWithValue("@Link", link);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para obtener un mensaje por su ID
        public Mensaje ObtenerMensajePorId(int idMensaje)
        {
            Mensaje mensaje = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM MENSAJE WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mensaje = new Mensaje
                            {
                                IdMensaje = reader.GetInt32("ID_MENSAJE"),
                                IdChat = reader.GetInt32("ID_CHAT"),
                                IdPerfilEnvia = reader.GetInt32("id_Perfil_Envia"),
                                IdPerfilRecibe = reader.GetInt32("id_Perfil_Recibe"),
                                FechaHora = reader.GetDateTime("FECHA_HORA")
                            };

                            // Obtener el contenido adicional
                            mensaje.Texto = ObtenerTextoPorId(mensaje.IdMensaje);
                            mensaje.Imagen = ObtenerImagenPorId(mensaje.IdMensaje);
                            mensaje.Link = ObtenerLinkPorId(mensaje.IdMensaje);
                        }
                    }
                }
            }

            return mensaje;
        }

        // Método para obtener el texto de un mensaje
        private string ObtenerTextoPorId(int idMensaje)
        {
            string texto = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT TEXTO FROM MENSAJE_TEXTO WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    texto = command.ExecuteScalar() as string;
                }
            }

            return texto;
        }

        // Método para obtener la imagen de un mensaje
        private string ObtenerImagenPorId(int idMensaje)
        {
            string imagen = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT IMAGEN FROM MENSAJE_IMAGEN WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    imagen = command.ExecuteScalar() as string;
                }
            }

            return imagen;
        }

        // Método para obtener el enlace de un mensaje
        private string ObtenerLinkPorId(int idMensaje)
        {
            string link = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT LINK FROM MENSAJE_LINK WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    link = command.ExecuteScalar() as string;
                }
            }

            return link;
        }

        // Método para eliminar un mensaje
        public void EliminarMensaje(int idMensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Primero, elimina el contenido adicional
                EliminarContenidoPorId(idMensaje);

                // Luego, elimina el mensaje
                var query = "DELETE FROM MENSAJE WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para eliminar el contenido adicional de un mensaje
        private void EliminarContenidoPorId(int idMensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM MENSAJE_TEXTO WHERE ID_MENSAJE = @IdMensaje; " +
                            "DELETE FROM MENSAJE_IMAGEN WHERE ID_MENSAJE = @IdMensaje; " +
                            "DELETE FROM MENSAJE_LINK WHERE ID_MENSAJE = @IdMensaje;";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar un mensaje
        public void ActualizarMensaje(Mensaje mensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE MENSAJE SET ID_CHAT = @IdChat, id_Perfil_Envia = @IdPerfilEnvia, id_Perfil_Recibe = @IdPerfilRecibe, FECHA_HORA = @FechaHora WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", mensaje.IdMensaje);
                    command.Parameters.AddWithValue("@IdChat", mensaje.IdChat);
                    command.Parameters.AddWithValue("@IdPerfilEnvia", mensaje.IdPerfilEnvia);
                    command.Parameters.AddWithValue("@IdPerfilRecibe", mensaje.IdPerfilRecibe);
                    command.Parameters.AddWithValue("@FechaHora", mensaje.FechaHora);
                    command.ExecuteNonQuery();
                }

                // Actualizar contenido según el tipo de mensaje
                switch (mensaje.Tipo)
                {
                    case Mensaje.MensajeTipo.Texto:
                        ActualizarTexto(mensaje.IdMensaje, mensaje.Texto);
                        break;
                    case Mensaje.MensajeTipo.Imagen:
                        ActualizarImagen(mensaje.IdMensaje, mensaje.Imagen);
                        break;
                    case Mensaje.MensajeTipo.Link:
                        ActualizarLink(mensaje.IdMensaje, mensaje.Link);
                        break;
                }
            }
        }

        // Método para actualizar el mensaje de texto
        private void ActualizarTexto(int idMensaje, string texto)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE MENSAJE_TEXTO SET TEXTO = @Texto WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.Parameters.AddWithValue("@Texto", texto);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar el mensaje de imagen
        private void ActualizarImagen(int idMensaje, string imagen)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE MENSAJE_IMAGEN SET IMAGEN = @Imagen WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.Parameters.AddWithValue("@Imagen", imagen);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar el mensaje de enlace
        private void ActualizarLink(int idMensaje, string link)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE MENSAJE_LINK SET LINK = @Link WHERE ID_MENSAJE = @IdMensaje";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMensaje", idMensaje);
                    command.Parameters.AddWithValue("@Link", link);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para obtener todos los mensajes
        public List<Mensaje> ObtenerTodosLosMensajes()
        {
            var mensajes = new List<Mensaje>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM MENSAJE";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var mensaje = new Mensaje
                            {
                                IdMensaje = reader.GetInt32("ID_MENSAJE"),
                                IdChat = reader.GetInt32("ID_CHAT"),
                                IdPerfilEnvia = reader.GetInt32("id_Perfil_Envia"),
                                IdPerfilRecibe = reader.GetInt32("id_Perfil_Recibe"),
                                FechaHora = reader.GetDateTime("FECHA_HORA"),
                                Texto = ObtenerTextoPorId(reader.GetInt32("ID_MENSAJE")),
                                Imagen = ObtenerImagenPorId(reader.GetInt32("ID_MENSAJE")),
                                Link = ObtenerLinkPorId(reader.GetInt32("ID_MENSAJE"))
                            };
                            mensajes.Add(mensaje);
                        }
                    }
                }
            }

            return mensajes;
        }
    }
}

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration; 

namespace DAL
{
    public class EventoDAL
    {
        private readonly string connectionString;

        // Constructor sin parámetros
        public EventoDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // nuevo evento
        public void InsertarEvento(Evento evento)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "INSERT INTO evento (nombre, descripcion, fecha) VALUES (@Nombre, @Descripcion, @Fecha)";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", evento.Nombre);
                command.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                command.Parameters.AddWithValue("@Fecha", evento.Fecha);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // eliminar un evento
        public void EliminarEvento(int idEvento)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "DELETE FROM evento WHERE id_evento = @IdEvento";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdEvento", idEvento);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // actualizar un evento
        public void ActualizarEvento(Evento evento)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "UPDATE evento SET nombre = @Nombre, descripcion = @Descripcion, fecha = @Fecha WHERE id_evento = @IdEvento";
                var command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdEvento", evento.IdEvento);
                command.Parameters.AddWithValue("@Nombre", evento.Nombre);
                command.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                command.Parameters.AddWithValue("@Fecha", evento.Fecha);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // obtener todos los eventos
        public List<Evento> ObtenerEventos()
        {
            var eventos = new List<Evento>();

            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM evento";
                var command = new MySqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var evento = new Evento
                        {
                            IdEvento = reader.GetInt32("id_evento"),
                            Nombre = reader.GetString("nombre"),
                            Descripcion = reader.GetString("descripcion"),
                            Fecha = reader.GetDateTime("fecha")
                        };
                        eventos.Add(evento);
                    }
                }
            }

            return eventos;
        }

        //  obtener un evento por su ID
        public Evento ObtenerEventoPorId(int idEvento)
        {
            Evento evento = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM evento WHERE id_evento = @IdEvento";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEvento", idEvento);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        evento = new Evento
                        {
                            IdEvento = reader.GetInt32("id_evento"),
                            Nombre = reader.GetString("nombre"),
                            Descripcion = reader.GetString("descripcion"),
                            Fecha = reader.GetDateTime("fecha")
                        };
                    }
                }
            }

            return evento;
        }
    }
}

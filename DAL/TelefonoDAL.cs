using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;  

namespace DAL
{
    public class TelefonoDAL
    {
        private readonly string connectionString;

        public TelefonoDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insertar(Telefono telefono)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "INSERT INTO telefono (id_perfil, telefono, tipo) VALUES (@IdPerfil, @Numero, @Tipo)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdPerfil", telefono.IdPerfil);
                command.Parameters.AddWithValue("@Numero", telefono.Numero);
                command.Parameters.AddWithValue("@Tipo", telefono.Tipo);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Telefono ObtenerPorId(int idPerfil, string numero)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM telefono WHERE id_perfil = @IdPerfil AND telefono = @Numero";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                command.Parameters.AddWithValue("@Numero", numero);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Telefono
                        {
                            IdPerfil = reader.GetInt32("id_perfil"),
                            Numero = reader.GetString("telefono"),
                            Tipo = reader.GetString("tipo")
                        };
                    }
                }
            }
            return null;
        }

        public void Actualizar(Telefono telefono)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "UPDATE telefono SET tipo = @Tipo WHERE id_perfil = @IdPerfil AND telefono = @Numero";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdPerfil", telefono.IdPerfil);
                command.Parameters.AddWithValue("@Numero", telefono.Numero);
                command.Parameters.AddWithValue("@Tipo", telefono.Tipo);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idPerfil, string numero)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "DELETE FROM telefono WHERE id_perfil = @IdPerfil AND telefono = @Numero";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                command.Parameters.AddWithValue("@Numero", numero);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Telefono> ObtenerTodos(int idPerfil)
        {
            var telefonos = new List<Telefono>();

            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM telefono WHERE id_perfil = @IdPerfil";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdPerfil", idPerfil);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        telefonos.Add(new Telefono
                        {
                            IdPerfil = reader.GetInt32("id_perfil"),
                            Numero = reader.GetString("telefono"),
                            Tipo = reader.GetString("tipo")
                        });
                    }
                }
            }
            return telefonos;
        }
    }
}

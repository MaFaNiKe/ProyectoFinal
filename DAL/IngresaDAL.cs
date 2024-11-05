using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;  

namespace DAL
{
    public class IngresaDAL
    {
        private readonly string connectionString;


        public IngresaDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // insertar un ingreso
        public void InsertarIngreso(Ingresa ingreso)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO ingresa (id_perfil, id_grupo, fecha_ingreso, rol) VALUES (@idPerfil, @idGrupo, @fechaIngreso, @rol)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPerfil", ingreso.IdPerfil);
                command.Parameters.AddWithValue("@idGrupo", ingreso.IdGrupo);
                command.Parameters.AddWithValue("@fechaIngreso", ingreso.FechaIngreso);
                command.Parameters.AddWithValue("@rol", ingreso.Rol);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // eliminar un ingreso
        public void EliminarIngreso(int idPerfil, int idGrupo)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM ingresa WHERE id_perfil = @idPerfil AND id_grupo = @idGrupo";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idPerfil", idPerfil);
                command.Parameters.AddWithValue("@idGrupo", idGrupo);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // obtener todos los ingresos
        public List<Ingresa> ObtenerIngresos()
        {
            var listaIngresos = new List<Ingresa>();

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM ingresa";
                var command = new MySqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ingreso = new Ingresa
                        {
                            IdPerfil = reader.GetInt32("id_perfil"),
                            IdGrupo = reader.GetInt32("id_grupo"),
                            FechaIngreso = reader.GetDateTime("fecha_ingreso"),
                            Rol = reader.GetString("rol")
                        };

                        listaIngresos.Add(ingreso);
                    }
                }
            }

            return listaIngresos;
        }
    }
}

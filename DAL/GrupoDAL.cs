using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration; 

namespace DAL
{
    public class GrupoDAL
    {
        private readonly string connectionString;

      
        public GrupoDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // insertar un grupo
        public void InsertarGrupo(Grupo grupo)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO grupo (id_grupo, nombre, texto_publico, comentarios, fecha_creacion) VALUES (@idGrupo, @nombre, @textoPublico, @comentarios, @fechaCreacion)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idGrupo", grupo.IdGrupo);
                command.Parameters.AddWithValue("@nombre", grupo.Nombre);
                command.Parameters.AddWithValue("@textoPublico", grupo.textoPublico);
                command.Parameters.AddWithValue("@comentarios", grupo.Comentarios);
                command.Parameters.AddWithValue("@fechaCreacion", grupo.FechaCreacion);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // eliminar un grupo
        public void EliminarGrupo(int idGrupo)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM grupo WHERE id_grupo = @idGrupo";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idGrupo", idGrupo);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // obtener todos los grupos
        public List<Grupo> ObtenerGrupos()
        {
            var listaGrupos = new List<Grupo>();

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM grupo";
                var command = new MySqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var grupo = new Grupo
                        {
                            IdGrupo = reader.GetInt32("id_grupo"),
                            Nombre = reader.GetString("nombre"),
                            textoPublico = reader.GetBoolean("texto_publico"),
                            Comentarios = reader.GetString("comentarios"),
                            FechaCreacion = reader.GetDateTime("fecha_creacion")
                        };

                        listaGrupos.Add(grupo);
                    }
                }
            }

            return listaGrupos;
        }
    }
}

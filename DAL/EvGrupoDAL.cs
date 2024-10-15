using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidades;
using System.Configuration;

namespace DAL
{
    public class EvGrupoDAL
    {
        private readonly string connectionString;

        // Constructor sin parámetros
        public EvGrupoDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // insertar un registro
        public void InsertarEvGrupo(EvGrupo evGrupo)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO ev_grupo (id_grupo, id_evento) VALUES (@idGrupo, @idEvento)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idGrupo", evGrupo.IdGrupo);
                command.Parameters.AddWithValue("@idEvento", evGrupo.IdEvento);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //  eliminar un registro
        public void EliminarEvGrupo(int idGrupo, int idEvento)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM ev_grupo WHERE id_grupo = @idGrupo AND id_evento = @idEvento";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@idGrupo", idGrupo);
                command.Parameters.AddWithValue("@idEvento", idEvento);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // obtener todos los registros
        public List<EvGrupo> ObtenerEvGrupos()
        {
            var listaEvGrupos = new List<EvGrupo>();

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM ev_grupo";
                var command = new MySqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var evGrupo = new EvGrupo
                        {
                            IdGrupo = reader.GetInt32("id_grupo"),
                            IdEvento = reader.GetInt32("id_evento")
                        };

                        listaEvGrupos.Add(evGrupo);
                    }
                }
            }

            return listaEvGrupos;
        }
    }
}

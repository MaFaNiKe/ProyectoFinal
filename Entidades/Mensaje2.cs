using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Entidades
{
    public class Mensaje2
    {
        public int IdMensaje { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCanal { get; set; }  

        // Constructor
        public Mensaje2(int idMensaje, string texto, DateTime fecha, int idCanal)
        {
            IdMensaje = idMensaje;
            Texto = texto;
            Fecha = fecha;
            IdCanal = idCanal;
        }

        public static List<Mensaje2> ObtenerTodosLosMensajes()
        {
            List<Mensaje2> mensajes = new List<Mensaje2>();
            using (MySqlConnection con = ConexionBD.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM mensaje2"; 
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Mensaje2 mensaje = new Mensaje2(
                        Convert.ToInt32(reader["ID_MENSAJE"]),
                        reader["TEXTO"].ToString(),
                        Convert.ToDateTime(reader["FECHA_HORA"]),
                        Convert.ToInt32(reader["ID_CANAL"])
                    );
                    mensajes.Add(mensaje);
                }
            }
            return mensajes;
        }

        public static Mensaje2 ObtenerMensajePorId(int idMensaje)
        {
            Mensaje2 mensaje = null;
            using (MySqlConnection con = ConexionBD.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT * FROM mensaje2 WHERE ID_MENSAJE = @idMensaje";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idMensaje", idMensaje);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    mensaje = new Mensaje2(
                        Convert.ToInt32(reader["ID_MENSAJE"]),
                        reader["TEXTO"].ToString(),
                        Convert.ToDateTime(reader["FECHA_HORA"]),
                        Convert.ToInt32(reader["ID_CANAL"])
                    );
                }
            }
            return mensaje;
        }

        public static bool CrearMensaje(string texto, DateTime fechaHora, int idCanal, int idPerfilEnvia)
        {
            try
            {
                
                string query = "INSERT INTO mensaje2 (TEXTO, FECHA_HORA, ID_CANAL, ID_PERFIL_ENVIA) VALUES (@texto, @fechaHora, @idCanal, @perfilEnvia)";
                using (MySqlConnection con = ConexionBD.ObtenerConexion())
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@texto", texto);
                    cmd.Parameters.AddWithValue("@fechaHora", fechaHora);
                    cmd.Parameters.AddWithValue("@idCanal", idCanal);
                    cmd.Parameters.AddWithValue("@perfilEnvia", idPerfilEnvia);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar el mensaje: {ex.Message}");
                return false;
            }
        }

        public static bool EliminarMensaje(int idMensaje)
        {
            bool exito = false;
            using (MySqlConnection con = ConexionBD.ObtenerConexion())
            {
                con.Open();
                string query = "DELETE FROM mensaje2 WHERE ID_MENSAJE = @idMensaje";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idMensaje", idMensaje);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    exito = true;
                }
            }
            return exito;
        }

        public static bool ActualizarMensaje(int idMensaje, string texto, DateTime fecha)
        {
            bool exito = false;
            using (MySqlConnection con = ConexionBD.ObtenerConexion())
            {
                con.Open();
                string query = "UPDATE mensaje2 SET texto = @texto, FECHA_HORA = @fecha WHERE ID_MENSAJE = @idMensaje";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@texto", texto);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@idMensaje", idMensaje);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    exito = true;
                }
            }
            return exito;
        }

        public static List<Mensaje2> ObtenerMensajesPorCanal(int idCanal)
        {
            List<Mensaje2> mensajes = new List<Mensaje2>();
            using (MySqlConnection con = ConexionBD.ObtenerConexion())
            {
                con.Open();
                // Hacemos el JOIN con la tabla de usuarios
                string query = @"SELECT m.ID_MENSAJE, m.TEXTO, m.FECHA_HORA, m.ID_CANAL, u.NOMBRE 
                                 FROM mensaje2 m 
                                 JOIN usuario u ON m.ID_PERFIL_ENVIA = u.id_Perfil
                                 WHERE m.ID_CANAL = @idCanal";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idCanal", idCanal);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Mensaje2 mensaje = new Mensaje2(
                        Convert.ToInt32(reader["ID_MENSAJE"]),
                        reader["TEXTO"].ToString(),
                        Convert.ToDateTime(reader["FECHA_HORA"]),
                        Convert.ToInt32(reader["ID_CANAL"])
                    );
                    mensajes.Add(mensaje);
                }
            }
            return mensajes;
        }

    }
}

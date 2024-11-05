using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using Entidades;
using System.Linq;
using Newtonsoft.Json; // Necesitamos esta librería para convertir a JSON

namespace DAL
{
    public class UsuarioDAL
    {
        private readonly string connectionString;

        public UsuarioDAL()
        {
            // cadena de conexión desde App.config
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public Usuario ObtenerUsuarioPorCorreo(string correo)
        {
            Usuario usuario = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM usuario WHERE correo = @Correo";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Correo", correo);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                IdPerfil = reader.GetInt32("id_perfil"),
                                Nombre = reader.GetString("nombre"),
                                Apellido = reader.GetString("apellido"),
                                Correo = reader.GetString("correo"),
                                Contrasena = reader.GetString("contrasena"),
                                FechaNac = reader.GetDateTime("fecha_nac"),
                                TipoUsuario = (TipoUsuarioEnum)Enum.Parse(typeof(TipoUsuarioEnum), reader.GetString("tipo_usuario"))
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public int ObtenerCantidadUsuarios()
        {
            int cantidadUsuarios = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM usuario";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cantidadUsuarios = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return cantidadUsuarios;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO usuario (id_perfil, nombre, apellido, correo, contrasena, fecha_nac) VALUES (@id_perfil, @nombre, @apellido, @correo, @contrasena, @fecha_nac)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@id_perfil", usuario.IdPerfil);
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                    cmd.Parameters.AddWithValue("@fecha_nac", usuario.FechaNac.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public Usuario ObtenerUsuarioPorId(int idPerfil)
        {
            Usuario usuario = null;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM usuario WHERE id_perfil = @IdPerfil";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                IdPerfil = reader.GetInt32("id_perfil"),
                                Nombre = reader.GetString("nombre"),
                                Apellido = reader.GetString("apellido"),
                                Correo = reader.GetString("correo"),
                                Contrasena = reader.GetString("contrasena"),
                                FechaNac = reader.GetDateTime("fecha_nac"), 
                                TipoUsuario = (TipoUsuarioEnum)Enum.Parse(typeof(TipoUsuarioEnum), reader.GetString("tipo_usuario"))
                            };
                        }
                    }
                }
            }
            return usuario;
        }



        public void ActualizarUsuario(Usuario usuario)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE usuario SET nombre = @Nombre, apellido = @Apellido, correo = @Correo, contrasena = @Contrasena, fecha_nac = @FechaNac, tipo_usuario = @TipoUsuario WHERE id_perfil = @IdPerfil";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPerfil", usuario.IdPerfil);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@Correo", usuario.Correo);
                    command.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    command.Parameters.AddWithValue("@FechaNac", usuario.FechaNac.ToString("yyyy-MM-dd")); 
                    command.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario.ToString());

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarUsuario(int idPerfil)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM usuario WHERE id_perfil = @IdPerfil";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdPerfil", idPerfil);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            var usuarios = new List<Usuario>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM usuario";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new Usuario
                            {
                                IdPerfil = reader.GetInt32("id_perfil"),
                                Nombre = reader.GetString("nombre"),
                                Apellido = reader.GetString("apellido"),
                                Correo = reader.GetString("correo"),
                                Contrasena = reader.GetString("contrasena"),
                                FechaNac = reader.GetDateTime("fecha_nac"),
                                TipoUsuario = (TipoUsuarioEnum)Enum.Parse(typeof(TipoUsuarioEnum), reader.GetString("tipo_usuario"))
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        public string ObtenerUsuariosEnJson()
        {
            // Lista para almacenar los usuarios
            var usuariosLista = new List<UsuarioDTO>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_perfil, nombre, apellido, correo FROM usuario";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Creamos un objeto UsuarioDTO con los datos relevantes
                            var usuario = new UsuarioDTO
                            {
                                IdPerfil = reader.GetInt32("id_perfil"),
                                Nombre = reader.GetString("nombre"),
                                Apellido = reader.GetString("apellido"),
                                Correo = reader.GetString("correo")
                            };
                            usuariosLista.Add(usuario);
                        }
                    }
                }
            }

            // Convertimos la lista de usuarios a JSON
            string jsonUsuarios = JsonConvert.SerializeObject(usuariosLista, Formatting.Indented);

            return jsonUsuarios; // Devolvemos el JSON resultante
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Entidades;

namespace UltimoAliento
{
    public partial class ChatForm : Form
    {
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=Proyecto_sans;User ID=root;Password=root;";
        private int currentUserId;
        Usuario user = new Usuario();

        public ChatForm(Usuario user)
        {
            this.user = user;
            InitializeComponent();
            currentUserId = user.IdPerfil;
            CargarChats();
        }

        private void CargarChats()
        {
            string query = "SELECT ID_CHAT, CHAT_GRUPAL FROM CHAT";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            lstChats.Items.Clear();
                            while (reader.Read())
                            {
                                int idChat = reader.GetInt32("ID_CHAT");
                                bool esGrupal = reader.GetBoolean("CHAT_GRUPAL");
                                string chatDisplay = "Chat " + idChat + (esGrupal ? " (Grupal)" : "");
                                lstChats.Items.Add(new ListBoxItem { IdChat = idChat, DisplayText = chatDisplay });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los chats: " + ex.Message);
                }
            }
        }

        private void CargarMensajes(int idChat)
        {
            string query = @"
                SELECT m.ID_MENSAJE, u.Nombre, u.Apellido, m.FECHA_HORA, mt.TEXTO 
                FROM MENSAJE m
                JOIN Usuario u ON m.id_Perfil_Envia = u.id_Perfil
                LEFT JOIN MENSAJE_TEXTO mt ON m.ID_MENSAJE = mt.ID_MENSAJE
                WHERE m.ID_CHAT = @idChat";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idChat", idChat);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            rtbMensajes.Clear();
                            while (reader.Read())
                            {
                                string nombreUsuario = reader.GetString("Nombre") + " " + reader.GetString("Apellido");
                                DateTime fechaHora = reader.GetDateTime("FECHA_HORA");
                                string textoMensaje = reader.IsDBNull(reader.GetOrdinal("TEXTO")) ? "[Sin texto]" : reader.GetString("TEXTO");
                                rtbMensajes.AppendText($"{nombreUsuario} ({fechaHora}): {textoMensaje}\n");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los mensajes: " + ex.Message);
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (lstChats.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecciona un chat.");
                return;
            }

            var selectedChat = (ListBoxItem)lstChats.SelectedItem;
            string mensajeTexto = txtMensaje.Text.Trim();

            if (string.IsNullOrEmpty(mensajeTexto))
            {
                MessageBox.Show("El mensaje no puede estar vacío.");
                return;
            }

            string queryMensaje = "INSERT INTO MENSAJE (ID_CHAT, id_Perfil_Envia, id_Perfil_Recibe, FECHA_HORA) VALUES (@idChat, @idPerfilEnvia, @idPerfilRecibe, @fechaHora)";
            string queryMensajeTexto = "INSERT INTO MENSAJE_TEXTO (ID_MENSAJE, TEXTO) VALUES (@idMensaje, @texto)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmdMensaje = new MySqlCommand(queryMensaje, connection, transaction))
                        {
                            cmdMensaje.Parameters.AddWithValue("@idChat", selectedChat.IdChat);
                            cmdMensaje.Parameters.AddWithValue("@idPerfilEnvia", currentUserId);
                            cmdMensaje.Parameters.AddWithValue("@idPerfilRecibe", DBNull.Value); // Cambiar si se trata de un chat grupal
                            cmdMensaje.Parameters.AddWithValue("@fechaHora", DateTime.Now);
                            cmdMensaje.ExecuteNonQuery();

                            long idMensaje = cmdMensaje.LastInsertedId;

                            using (MySqlCommand cmdMensajeTexto = new MySqlCommand(queryMensajeTexto, connection, transaction))
                            {
                                cmdMensajeTexto.Parameters.AddWithValue("@idMensaje", idMensaje);
                                cmdMensajeTexto.Parameters.AddWithValue("@texto", mensajeTexto);
                                cmdMensajeTexto.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        txtMensaje.Clear();
                        CargarMensajes(selectedChat.IdChat);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al enviar el mensaje: " + ex.Message);
                    }
                }
            }
        }

        private void lstChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChats.SelectedItem is ListBoxItem selectedChat)
            {
                CargarMensajes(selectedChat.IdChat);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Implementar búsqueda
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Manejar la carga de archivos adjuntos
            }
        }

        private void CrearNuevoChat(int idUsuario)
        {
            string queryChat = "INSERT INTO CHAT (chat_grupal) VALUES (0);"; // 0 significa que es un chat privado
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar nuevo chat en la tabla CHAT
                        using (MySqlCommand cmdChat = new MySqlCommand(queryChat, connection, transaction))
                        {
                            cmdChat.ExecuteNonQuery();
                            long idChatNuevo = cmdChat.LastInsertedId; // Obtener el ID del chat recién creado

                            // Agregar un mensaje inicial en la tabla MENSAJE
                            string queryMensajeInicial = "INSERT INTO MENSAJE (id_chat, id_perfil_envia, id_perfil_recibe, fecha_hora) " +
                                                         "VALUES (@idChat, @idPerfilEnvia, @idPerfilRecibe, @fechaHora)";
                            using (MySqlCommand cmdMensajeInicial = new MySqlCommand(queryMensajeInicial, connection, transaction))
                            {
                                cmdMensajeInicial.Parameters.AddWithValue("@idChat", idChatNuevo);
                                cmdMensajeInicial.Parameters.AddWithValue("@idPerfilEnvia", currentUserId); // El ID del usuario que envía el mensaje
                                cmdMensajeInicial.Parameters.AddWithValue("@idPerfilRecibe", idUsuario); // El ID del usuario que recibe el mensaje
                                cmdMensajeInicial.Parameters.AddWithValue("@fechaHora", DateTime.Now); // Fecha y hora actuales
                                cmdMensajeInicial.ExecuteNonQuery();
                            }

                            transaction.Commit(); // Confirmar transacción
                            txtBoxNuevoChat.Clear(); // Limpiar el campo de texto
                            CargarChats(); // Refrescar la lista de chats
                            MessageBox.Show("Chat creado exitosamente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Revertir cambios en caso de error
                        MessageBox.Show("Error al crear el chat: " + ex.Message);
                    }
                }
            }
        }


        private class ListBoxItem
        {
            public int IdChat { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private void btnCrearChat_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Este botón funciona");
            string correoNuevoChat = txtBoxNuevoChat.Text.Trim();
            if (string.IsNullOrEmpty(correoNuevoChat))
            {
                MessageBox.Show("Por favor, ingresa un correo para crear un nuevo chat.");
                return;
            }

            // Verificar si el usuario con el correo existe
            string queryUsuario = "SELECT id_Perfil FROM Usuario WHERE Correo = @correo";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(queryUsuario, connection))
                    {
                        cmd.Parameters.AddWithValue("@correo", correoNuevoChat);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int idUsuario = Convert.ToInt32(result);
                            CrearNuevoChat(idUsuario);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún usuario con ese correo.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar el usuario: " + ex.Message);
                }
            }
        }
    }
}

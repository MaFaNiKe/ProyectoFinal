using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Entidades;

namespace UltimoAliento
{
    public partial class ChatForm : Form
    {
        private List<Canal> canales; // Lista de canales
        private Canal canalSeleccionado; // Canal actualmente seleccionado
        private string archivoAdjunto; // Ruta del archivo adjunto
        private Usuario user;

        public ChatForm(Usuario usuario)
        {
            InitializeComponent();
            this.user = usuario;
            canales = new List<Canal>();
            CargarChats(); // Cargamos los chats (canales) al iniciar el formulario
        }
        private void CargarChats()
        {
            try
            {
                canales = Canal.ObtenerTodosLosCanales(); // Obtenemos los canales de la base de datos
                ActualizarDataGridView(); // Actualizamos el DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los canales: {ex.Message}");
            }
        }
        private void ActualizarDataGridView()
        {
            dtgChats.Rows.Clear();
            dtgChats.Columns.Clear();
            dtgChats.Columns.Add("IdCanal", "ID");
            dtgChats.Columns.Add("NombreCanal", "Canales");

            foreach (var canal in canales)
            {
                dtgChats.Rows.Add(canal.IdCanal, canal.NombreCanal);
            }

            dtgChats.Columns["IdCanal"].Visible = false;
        }
        private void dtgChats_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgChats.SelectedRows.Count > 0)
            {
                int idSeleccionado = Convert.ToInt32(dtgChats.SelectedRows[0].Cells["IdCanal"].Value);
                canalSeleccionado = canales.Find(c => c.IdCanal == idSeleccionado);
                MostrarMensajes(); 
            }
        }
        private void MostrarMensajes()
        {
            rtbMensajes.Clear();
            if (canalSeleccionado != null)
            {
                var mensajes = Mensaje2.ObtenerMensajesPorCanal(canalSeleccionado.IdCanal);
                MessageBox.Show($"Mensajes encontrados: {mensajes.Count}");
                foreach (var mensaje in mensajes)
                {
                    rtbMensajes.AppendText($"[{mensaje.Fecha}] : {mensaje.Texto}\n");
                }
            }
        }
        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            if (canalSeleccionado == null)
            {
                MessageBox.Show("No se ha seleccionado un canal.");
                return;
            }

            if (!string.IsNullOrEmpty(txtMensaje.Text))
            {
                bool exito = Mensaje2.CrearMensaje(txtMensaje.Text, DateTime.Now, canalSeleccionado.IdCanal, user.IdPerfil);
                if (exito)
                {
                    txtMensaje.Clear();
                    MostrarMensajes(); // Recargamos los mensajes después de enviar
                }
                else
                {
                    MessageBox.Show("Error al enviar el mensaje.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un mensaje.");
            }
        }
        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            archivoAdjunto = openFileDialog1.FileName;
            MessageBox.Show($"Archivo adjunto: {Path.GetFileName(archivoAdjunto)}");
        }
        private void CargarChat_Click(object sender, EventArgs e)
        {
            CargarChats(); 
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}

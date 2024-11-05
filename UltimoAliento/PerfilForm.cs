using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using DAL;  // Para la interacción con la base de datos
using Newtonsoft.Json;  // Para manejar la deserialización de JSON

namespace UltimoAliento
{
    public partial class PerfilForm : Form
    {
        private Usuario usuario;
        private UsuarioDAL usuarioDAL;  // Acceso a la capa de datos


        public PerfilForm(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            usuarioDAL = new UsuarioDAL();  // Inicializamos UsuarioDAL para obtener los usuarios
            CargarDatosUsuario();
            CargarUsuariosEnDataGrid();  // Cargamos la lista de usuarios en el DataGridView   
        }

       
        private void CargarDatosUsuario()
        {
            if (usuario != null)
            {
                textBoxId.Text = Convert.ToString(usuario.IdPerfil);
                textBoxNombre.Text = usuario.Nombre;
                textBoxApellido.Text = usuario.Apellido;
                textBoxCorreo.Text = usuario.Correo;
                textBoxContraseña.Text = usuario.Contrasena; 
                textBoxFechaNac.Text = usuario.FechaNac.ToShortDateString();
                textBoxPrivilegios.Text = Convert.ToString(usuario.TipoUsuario);
               // textBoxTelefono.Text = Convert.ToString(usuario.Telefonos);
            }
            else
            {
                MessageBox.Show("No se ha pasado un usuario válido.");
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Método para cargar la lista de usuarios en el DataGridView
        private void CargarUsuariosEnDataGrid()
        {
            // Obtenemos el JSON de los usuarios desde UsuarioDAL
            string jsonUsuarios = usuarioDAL.ObtenerUsuariosEnJson();

            // Deserializamos el JSON en una lista de UsuarioDTO
            List<UsuarioDTO> listaUsuarios = JsonConvert.DeserializeObject<List<UsuarioDTO>>(jsonUsuarios);

            // Asignamos la lista deserializada al DataGridView
            dataGridViewAmigos.DataSource = listaUsuarios;

            // Personalizamos las columnas del DataGridView (opcional)
            dataGridViewAmigos.Columns["IdPerfil"].HeaderText = "ID";
            dataGridViewAmigos.Columns["Nombre"].HeaderText = "Nombre";
            dataGridViewAmigos.Columns["Apellido"].HeaderText = "Apellido";
            dataGridViewAmigos.Columns["Correo"].HeaderText = "Correo";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using DAL;
using Newtonsoft.Json; 

namespace UltimoAliento
{
    public partial class PerfilForm : Form
    {
        private Usuario usuario;
        private UsuarioDAL usuarioDAL;


        public PerfilForm(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            usuarioDAL = new UsuarioDAL();
            CargarDatosUsuario();
            CargarUsuariosEnDataGrid();
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

        private void CargarUsuariosEnDataGrid()
        {
            string jsonUsuarios = usuarioDAL.ObtenerUsuariosEnJson();

            List<UsuarioDTO> listaUsuarios = JsonConvert.DeserializeObject<List<UsuarioDTO>>(jsonUsuarios);

            dataGridViewAmigos.DataSource = listaUsuarios;

            dataGridViewAmigos.Columns["IdPerfil"].HeaderText = "ID";
            dataGridViewAmigos.Columns["Nombre"].HeaderText = "Nombre";
            dataGridViewAmigos.Columns["Apellido"].HeaderText = "Apellido";
            dataGridViewAmigos.Columns["Correo"].HeaderText = "Correo";
        }
    }
}

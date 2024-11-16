using System;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace UltimoAliento
{
    public partial class IniciarSesion : Form
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void BotonIniciarSesion_Click(object sender, EventArgs e)
        {
            
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese su correo y contraseña.");
                return;
            }
 
            if (!correo.Contains("@"))
            {
                MessageBox.Show("Correo no válido.");
                return;
            }

            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                Usuario usuario = usuarioBLL.IniciarSesion(correo, contrasena); 

                if (usuario != null)
                {
                    MessageBox.Show("Inicio de sesión exitoso.");
                    this.Hide();
                    PantallaPrincipal pantallaPrincipal = new PantallaPrincipal(usuario);
                    pantallaPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

 

        private void BotonRegistrarse_Click_1(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }
    }
}

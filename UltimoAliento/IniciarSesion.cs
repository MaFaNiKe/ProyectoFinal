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
            // Capturar los datos de entrada
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;

            // Validaciones básicas
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese su correo y contraseña.");
                return;
            }

            // Validar que el formato del correo sea correcto
            if (!correo.Contains("@"))
            {
                MessageBox.Show("Correo no válido.");
                return;
            }

            try
            {
                // Llamada al método del negocio (BLL) para verificar las credenciales
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                Usuario usuario = usuarioBLL.IniciarSesion(correo, contrasena); // Método que debes implementar en BLL

                if (usuario != null)
                {
                    // Si el inicio de sesión es correcto, redirigir a la pantalla principal
                    MessageBox.Show("Inicio de sesión exitoso.");
                    // Aquí puedes abrir una nueva ventana o redirigir a la siguiente pantalla
                    this.Hide();
                    PantallaPrincipal pantallaPrincipal = new PantallaPrincipal(usuario);
                    pantallaPrincipal.Show();
                }
                else
                {
                    // Si el inicio de sesión falla
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
            
            // Instanciar y mostrar el formulario de registro
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            
        }
    }
}

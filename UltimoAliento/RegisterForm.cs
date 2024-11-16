using System;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace UltimoAliento
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;
            string fechaNacString = txtFechaNac.Text;

           
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena) ||
                string.IsNullOrEmpty(fechaNacString))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

           
            if (nombre.Length > 20 || apellido.Length > 20 ||
            correo.Length > 40 || contrasena.Length > 20)
            {
                MessageBox.Show("Caracteres max: /n Nombre: 20 max | Apellido: 20 max | correo: 40max | contraseña: 20");
                return;
            }

           
            if (!DateTime.TryParse(fechaNacString, out DateTime fechaNac))
            {
                MessageBox.Show("Fecha de nacimiento no válida. Debe ser en formato correcto.");
                return;
            }

           
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Contrasena = contrasena,
                FechaNac = fechaNac,
                TipoUsuario = TipoUsuarioEnum.comun 
            };

            
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBLL.AgregarUsuario(nuevoUsuario);

            MessageBox.Show("Registro exitoso.");
            this.Hide();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            
            IniciarSesion form1 = new IniciarSesion();
            form1.Show();
            this.Close(); // Cierra el formulario de registro
        }
    }
}

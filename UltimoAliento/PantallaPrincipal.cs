using System;
using System.Windows.Forms;
using Entidades;

namespace UltimoAliento
{
    public partial class PantallaPrincipal : Form
    {
        public Usuario usuario;

        public PantallaPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            CargarPublicaciones();
        }

        private void CargarPublicaciones()
        {

        }

        private void BotonNuevaPublicacion_Click(object sender, EventArgs e)
        {
            // Crear un nuevo panel para el post
            Panel postPanel = new Panel();
            postPanel.Width = 400;
            postPanel.Height = 150;
            postPanel.BorderStyle = BorderStyle.FixedSingle;

            // Crear un FlowLayoutPanel interno para organizar el contenido de arriba hacia abajo
            FlowLayoutPanel contentLayout = new FlowLayoutPanel();
            contentLayout.FlowDirection = FlowDirection.TopDown;
            contentLayout.Dock = DockStyle.Fill;

            // Crear el label con el nombre y la fecha
            Label lblNombreFecha = new Label();
            lblNombreFecha.Text = "Nombre : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblNombreFecha.AutoSize = true;

            // Crear otro FlowLayoutPanel para contener el PictureBox y el texto del post
            FlowLayoutPanel postContentLayout = new FlowLayoutPanel();
            postContentLayout.FlowDirection = FlowDirection.LeftToRight;
            postContentLayout.AutoSize = true;

            // Crear el PictureBox a la izquierda
            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = 50;
            pictureBox.Height = 50;
            //pictureBox.Image = Image.FromFile("ruta_a_tu_imagen"); // Coloca la ruta correcta de la imagen
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            // Crear el Label que contendrá el texto del post a la derecha del PictureBox
            Label lblTextoPost = new Label();
            lblTextoPost.Text = "Este es el texto del post.";
            lblTextoPost.AutoSize = true;
            lblTextoPost.Width = 300; // Puedes ajustar el ancho

            // Añadir el PictureBox y el Label al FlowLayoutPanel postContentLayout
            postContentLayout.Controls.Add(pictureBox);
            postContentLayout.Controls.Add(lblTextoPost);

            // Crear el botón de "Like"
            Button btnLike = new Button();
            btnLike.Text = "Like";
            btnLike.Tag = 0; // Inicialmente el botón no ha sido presionado

            // Crear el Label para mostrar la cantidad de likes
            Label lblLikes = new Label();
            lblLikes.Text = "Likes: 0";
            lblLikes.AutoSize = true;

            // Añadir funcionalidad al botón de "Like"
            btnLike.Click += (s, evt) =>
            {
                if ((int)btnLike.Tag == 0) // Verificamos si ya se ha presionado
                {
                    int likesCount = int.Parse(lblLikes.Text.Split(':')[1].Trim());
                    likesCount++;
                    lblLikes.Text = "Likes: " + likesCount;
                    btnLike.Tag = 1; // Marcar el botón como presionado para evitar más clics
                    btnLike.Enabled = false; // Deshabilitar el botón
                }
            };

            // Añadir los controles al contentLayout
            contentLayout.Controls.Add(lblNombreFecha);
            contentLayout.Controls.Add(postContentLayout);
            contentLayout.Controls.Add(btnLike);
            contentLayout.Controls.Add(lblLikes);

            // Añadir el contentLayout al panel
            postPanel.Controls.Add(contentLayout);

            // Añadir el panel al FlowLayoutPanel principal
            flowLayoutPanelPosts.Controls.Add(postPanel);
            MessageBox.Show("Funcionalidad aún no implementada.");
        }

        private void BotonCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion inicioSesion = new IniciarSesion();
            inicioSesion.Show();
        }

        private void BotonConfiguracion_Click(object sender, EventArgs e)
        {
            // Abre una ventana de configuración 
            MessageBox.Show("Ventana de Configuración (por implementar)");
        }

        private void BotonNotificaciones_Click(object sender, EventArgs e)
        {
            // Lógica para abrir ventana de notificaciones
            MessageBox.Show("Ventana de Notificaciones (por implementar)");
        }

        private void perfilMenuItem_Click_1(object sender, EventArgs e)
        {
            PerfilForm perfilForm = new PerfilForm(usuario);
            perfilForm.Show();
        }

        private void mensajesMenuItem_Click(object sender, EventArgs e)
        {
            ChatForm mensajesForm = new ChatForm(usuario); // Suponiendo que necesitas pasar un usuario

            // Mostrar la ventana de mensajes
            mensajesForm.Show();  // Usa ShowDialog() si quieres que sea modal y bloquee la ventana actual
        }

        private void crearPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia de la ventana CrearPost
            CrearPost crearPostForm = new CrearPost();

            // Mostrar la ventana
            crearPostForm.Show();
        }
    }
}
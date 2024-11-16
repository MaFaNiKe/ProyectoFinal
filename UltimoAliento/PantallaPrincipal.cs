using System;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using DAL;
using System.Collections.Generic;

namespace UltimoAliento
{
    public partial class PantallaPrincipal : Form
    {
        public Usuario usuario;
        private PostDAL postDAL;
        private LikesDAL likeDAL; 

        public PantallaPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            postDAL = new PostDAL();
            likeDAL = new LikesDAL();
            CargarPublicaciones();
            CargarAnuncios();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        public void CargarAnuncios() 
        {
            try
            {
               
                string videoPath = @"C:\Users\matir\source\repos\UltimoAliento\Anuncios\CocaVagabundaCola.mp4"; // Cambiarla más adelante para una ruta válida del server

                axWindowsMediaPlayer1.URL = videoPath;
                axWindowsMediaPlayer1.settings.setMode("loop", true); 
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el video: " + ex.Message);
            }
        }

        public void CargarPublicaciones()
        {
            try
            {
                List<Post> postsDesdeDB = postDAL.ObtenerTodosLosPosts();
                int cantidadPostsEnAplicacion = flowLayoutPanelPosts.Controls.Count;

                foreach (var post in postsDesdeDB.Skip(cantidadPostsEnAplicacion))
                {
                    CargarPostEnInterfaz(post);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las publicaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPostEnInterfaz(Post post)
        {
            var postPanel = new Panel
            {
                Width = 400,
                Height = 150,
                BorderStyle = BorderStyle.FixedSingle
            };

            var contentLayout = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill
            };

            var lblNombreFecha = new Label
            {
                Text = $"Nombre: {post.NombreUsuario}  Fecha: {post.Fecha:dd/MM/yyyy HH:mm}",
                AutoSize = true
            };

            var postContentLayout = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true
            };

            var pictureBox = new PictureBox
            {
                Width = 50,
                Height = 50,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            var lblTextoPost = new Label
            {
                Text = post.Texto ?? "Sin texto",
                AutoSize = true,
                Width = 300
            };

            postContentLayout.Controls.Add(pictureBox);
            postContentLayout.Controls.Add(lblTextoPost);

            var btnLike = new Button
            {
                Text = "Like",
                Tag = likeDAL.PerfilYaDioLike(usuario.IdPerfil, post.IdPerfil) ? 1 : 0
            };

            var lblLikes = new Label
            {
                Text = $"Likes: {likeDAL.ObtenerCantidadLikes(post.IdPost)}",
                AutoSize = true
            };

            if ((int)btnLike.Tag == 1)
            {
                btnLike.Enabled = false;
            }

            btnLike.Click += (s, evt) =>
            {
                if ((int)btnLike.Tag == 0) 
                {
                    
                    likeDAL.AgregarLike(new Likes(post.IdPost, usuario.IdPerfil));

                    int likesCount = likeDAL.ObtenerCantidadLikes(post.IdPost);
                    lblLikes.Text = $"Likes: {likesCount}";

                    btnLike.Tag = 1;
                    btnLike.Enabled = false;
                }
            };

            contentLayout.Controls.Add(lblNombreFecha);
            contentLayout.Controls.Add(postContentLayout);
            contentLayout.Controls.Add(btnLike);
            contentLayout.Controls.Add(lblLikes);

            postPanel.Controls.Add(contentLayout);
            flowLayoutPanelPosts.Controls.Add(postPanel);
        }

        private void BotonCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            var inicioSesion = new IniciarSesion();
            inicioSesion.Show();
        }

        private void BotonConfiguracion_Click(object sender, EventArgs e)
        {
            var config = new ConfigForm();
            config.Show();
        }

        private void BotonNotificaciones_Click(object sender, EventArgs e)
        {
            var notificForm = new NotificacionesForm();
            notificForm.Show();
        }

        private void perfilMenuItem_Click(object sender, EventArgs e)
        {
            var perfilForm = new PerfilForm(usuario);
            perfilForm.Show();
        }

        private void mensajesMenuItem_Click(object sender, EventArgs e)
        {
            var mensajesForm = new ChatForm(usuario);
            mensajesForm.Show(); 
        }

        private void crearPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var crearPostForm = new CrearPost(usuario);
            crearPostForm.Show();
        }

        private void actualizarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CargarPublicaciones();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

using System.Text.Json;
using System.Windows.Forms;
using Entidades;
using DAL;

namespace UltimoAliento
{
    public partial class CrearPost : Form
    {
        private Usuario usuarioLogueado;
        private string rutaArchivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "posts.json");

        public CrearPost(Usuario usuario)
        {
            InitializeComponent();
            this.usuarioLogueado = usuario;

            if (usuarioLogueado == null)
            {
                MessageBox.Show("Error: usuarioLogueado es null.");
            }

            CargarDatosIniciales();
        }

        private void CargarDatosIniciales()
        {
            if (usuarioLogueado != null)
            {
                UsuarioActual.Text = $"{usuarioLogueado.Nombre} {usuarioLogueado.Apellido}";
                UsuarioActual.ReadOnly = true;

                FechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                FechaActual.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Error: No se ha proporcionado un usuario válido.");
            }
        }

        private void botonNuevaPublicacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTextoPost.Text))
            {
                MessageBox.Show("El texto del post no puede estar vacío.");
                return;
            }

            Post nuevoPost = new Post
            {
                IdPerfil = usuarioLogueado.IdPerfil,
                Fecha = DateTime.Now,
                Texto = textBoxTextoPost.Text,
                Likes = Convert.ToInt32(label4.Text)
            };

            PostDAL postDAL = new PostDAL();

            try
            {
                nuevoPost.IdPost = postDAL.AgregarPost(nuevoPost);

                // Guardar el nuevo post en el archivo JSON
                GuardarPostEnJson(nuevoPost);

                MessageBox.Show("Post creado exitosamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el post: {ex.Message}");
            }
        }

        private void GuardarPostEnJson(Post post)
        {
            List<Post> posts = new List<Post>();

            // Si el archivo JSON ya existe, cargar los posts existentes
            if (File.Exists(rutaArchivoJson))
            {
                string jsonExistente = File.ReadAllText(rutaArchivoJson);
                posts = JsonSerializer.Deserialize<List<Post>>(jsonExistente) ?? new List<Post>();
            }

            // Agregar el nuevo post a la lista y guardarla en el archivo
            posts.Add(post);
            string nuevoJson = JsonSerializer.Serialize(posts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(rutaArchivoJson, nuevoJson);
        }

        private void buttonVolver2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

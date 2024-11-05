using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PostImagen
    {
        public int IdImagen { get; set; }
        public int IdPost { get; set; }
        public string UrlImagen { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaSubida { get; set; }

        // Relaciones
        public Post Post { get; set; } 

        // Constructor
        public PostImagen()
        {
            FechaSubida = DateTime.Now; // Establece la fecha de subida por defecto al momento de la creación
        }

        public PostImagen(int idImagen, int idPost, string urlImagen, string descripcion, DateTime fechaSubida)
        {
            IdImagen = idImagen;
            IdPost = idPost;
            UrlImagen = urlImagen;
            Descripcion = descripcion;
            FechaSubida = fechaSubida;
        }

        // Métodos adicionales
        public void ActualizarDescripcion(string nuevaDescripcion)
        {
            if (string.IsNullOrEmpty(nuevaDescripcion))
                throw new ArgumentException("La descripción no puede estar vacía.");

            Descripcion = nuevaDescripcion;
        }

        public bool EsImagenValida()
        {
            // Verifica si la URL de la imagen es válida
            return Uri.IsWellFormedUriString(UrlImagen, UriKind.Absolute);
        }

        public override string ToString()
        {
            return $"Imagen {IdImagen} en Post {IdPost}: {UrlImagen} (Fecha de subida: {FechaSubida.ToShortDateString()})";
        }
    }
}

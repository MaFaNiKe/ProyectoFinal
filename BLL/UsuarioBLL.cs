using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL usuarioDAL;

        public UsuarioBLL()
        {
            usuarioDAL = new UsuarioDAL();
        }

        // iniciar sesión
        public Usuario IniciarSesion(string correo, string contrasena)
        {
            var usuario = usuarioDAL.ObtenerUsuarioPorCorreo(correo);
            if (usuario != null && usuario.Contrasena == contrasena)
            {
                return usuario; // Retorna el usuario si las credenciales son correctas
            }
            return null; // Retorna null si las credenciales son incorrectas
        }

        public void AgregarUsuario(Usuario usuario)
        {
            // Verificar si la fecha de nacimiento es válida
            if (!DateTime.TryParseExact(usuario.FechaNac.ToString("yyyyMMdd"), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime fechaNac))
            {
                throw new ArgumentException("La fecha de nacimiento no es válida. Debe estar en formato 'yyyyMMdd'.");
            }
            usuario.FechaNac = fechaNac; // Asigna el valor convertido

            usuarioDAL.AgregarUsuario(usuario);
        }

        public Usuario ObtenerUsuarioPorCorreo(string correo)
        {
            return usuarioDAL.ObtenerUsuarioPorCorreo(correo);
        }

        public int ObtenerCantidadUsuarios()
        {
            return usuarioDAL.ObtenerCantidadUsuarios();
        }

        public Usuario ObtenerUsuarioPorId(int idPerfil)
        {
            return usuarioDAL.ObtenerUsuarioPorId(idPerfil);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            usuarioDAL.ActualizarUsuario(usuario);
        }

        public void EliminarUsuario(int idPerfil)
        {
            usuarioDAL.EliminarUsuario(idPerfil);
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return usuarioDAL.ObtenerTodosLosUsuarios();
        }
    }
}

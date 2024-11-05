using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class TelefonoBLL
    {
        private readonly TelefonoDAL telefonoDAL;

        public TelefonoBLL()
        {
            telefonoDAL = new TelefonoDAL(); 
        }

        public void Insertar(Telefono telefono)
        {
            telefonoDAL.Insertar(telefono);
        }

        public Telefono ObtenerPorId(int idPerfil, string numero)
        {
            return telefonoDAL.ObtenerPorId(idPerfil, numero);
        }

        public void Actualizar(Telefono telefono)
        {
            telefonoDAL.Actualizar(telefono);
        }

        public void Eliminar(int idPerfil, string numero)
        {
            telefonoDAL.Eliminar(idPerfil, numero);
        }

        public List<Telefono> ObtenerTodos(int idPerfil)
        {
            return telefonoDAL.ObtenerTodos(idPerfil);
        }
    }
}

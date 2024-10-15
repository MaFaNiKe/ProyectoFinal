using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class IngresaBLL
    {
        private readonly IngresaDAL ingresaDAL;

        public IngresaBLL()
        {
            ingresaDAL = new IngresaDAL(); 
        }

        public void InsertarIngreso(Ingresa ingreso)
        {
            ingresaDAL.InsertarIngreso(ingreso);
        }

        public void EliminarIngreso(int idPerfil, int idGrupo)
        {
            ingresaDAL.EliminarIngreso(idPerfil, idGrupo);
        }

        public List<Ingresa> ObtenerIngresos()
        {
            return ingresaDAL.ObtenerIngresos();
        }
    }
}

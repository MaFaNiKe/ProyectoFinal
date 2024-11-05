using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class GrupoBLL
    {
        private readonly GrupoDAL grupoDAL;

        public GrupoBLL()
        {
            grupoDAL = new GrupoDAL(); 
        }

        public void InsertarGrupo(Grupo grupo)
        {
            grupoDAL.InsertarGrupo(grupo);
        }

        public void EliminarGrupo(int idGrupo)
        {
            grupoDAL.EliminarGrupo(idGrupo);
        }

        public List<Grupo> ObtenerGrupos()
        {
            return grupoDAL.ObtenerGrupos();
        }
    }
}

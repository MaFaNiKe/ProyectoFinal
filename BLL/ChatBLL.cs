using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class ChatBLL
    {
        private readonly ChatDAL chatDAL;

        public ChatBLL()
        {
            chatDAL = new ChatDAL();
        }

        public void Insertar(Chat chat)
        {
            if (chat == null)
                throw new ArgumentNullException(nameof(chat));

            chatDAL.Insertar(chat);
        }

        public Chat ObtenerPorId(int idChat)
        {
            return chatDAL.ObtenerPorId(idChat);
        }

        public void Actualizar(Chat chat)
        {
            if (chat == null)
                throw new ArgumentNullException(nameof(chat));

            chatDAL.Actualizar(chat);
        }

        public void Eliminar(int idChat)
        {
            chatDAL.Eliminar(idChat);
        }

        public List<Chat> ObtenerTodos()
        {
            return chatDAL.ObtenerTodos();
        }
    }
}

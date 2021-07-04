using AcademiaMW.Business.Models;
using AcademiaMW.Core.Messages;
using System;

namespace AcademiaMW.Business.Events
{
    public class CodigoConfirmacaoEvent : Event
    {
        public UsuarioConfirmacao UsuarioConfirmacao { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public CodigoConfirmacaoEvent(Guid usuarioId, string email, string nomeUsuario)
        {
            NomeUsuario = nomeUsuario;
            Email = email;
            UsuarioConfirmacao = new UsuarioConfirmacao(usuarioId);
        }
    }
}

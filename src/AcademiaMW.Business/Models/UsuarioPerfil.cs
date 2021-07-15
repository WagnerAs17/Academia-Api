using AcademiaMW.Core.Domain;
using System;

namespace AcademiaMW.Business.Models
{
    public class UsuarioPerfil : Entity
    {
        public Guid PerfilId { get; private set; }
        public Perfil Perfil { get; set; }
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; set; }
        
        public UsuarioPerfil(Guid perfilId, Guid usuarioId)
        {
            PerfilId = perfilId;
            UsuarioId = usuarioId;
        }

        //EF
        protected UsuarioPerfil() { }
    }
}

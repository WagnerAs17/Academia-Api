using AcademiaMW.Core.Domain;
using System;

namespace AcademiaMW.Business.Models
{
    public class Permissao : Entity, IAggregateRoot
    {
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; set; }
        public string ClaimType { get; private set; }
        public string ClaimValue { get; private set; }

        public Permissao(Guid usuarioId, string claimType, string claimValue)
        {
            UsuarioId = usuarioId;
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        //EF
        protected Permissao() { }
    }
}

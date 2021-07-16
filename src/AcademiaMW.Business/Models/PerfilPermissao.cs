using AcademiaMW.Core.Domain;
using System;

namespace AcademiaMW.Business.Models
{
    public class PerfilPermissao : Entity
    {
        public Guid PerfilId { get; private set; }
        public Perfil Perfil { get; private set; }
        public string ClaimType { get; private set; }
        public string ClaimValue { get; private set; }

        public PerfilPermissao(Guid perfilId, string claimType, string claimValue)
        {
            PerfilId = perfilId;
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public override bool EhValido()
        {
            return !string.IsNullOrEmpty(ClaimValue) && !string.IsNullOrEmpty(ClaimType);
        }

        //EF
        protected PerfilPermissao() { }
    }
}

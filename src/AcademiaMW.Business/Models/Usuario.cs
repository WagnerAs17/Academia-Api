using AcademiaMW.Core.Domain;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class Usuario : Entity, IAggregateRoot
    {
        public bool EmailConfirmado { get; private set; }
        public bool Ativo { get; private set; }
        public ICollection<Permissao> Permissoes { get; set; }

        public Usuario()
        {
            EmailConfirmado = false;
            Ativo = false;
        }

        public void AtivarEmail()
        {
            EmailConfirmado = true;
        }
    }

}

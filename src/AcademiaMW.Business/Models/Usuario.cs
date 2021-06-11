using AcademiaMW.Core.Domain;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class Usuario : Entity, IAggregateRoot
    {
        public bool EmailConfirmado { get; private set; }
        public bool Ativo { get; private set; }
        public ICollection<Permissao> Permissoes { get; set; }
        public string Senha { get; private set; }

        public Usuario(string senha)
        {
            Senha = senha;
            EmailConfirmado = false;
            Ativo = false;
        }

        //EF
        protected Usuario() { }

        public void AtivarEmail()
        {
            EmailConfirmado = true;
        }
    }

}

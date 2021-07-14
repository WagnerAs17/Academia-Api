using AcademiaMW.Core.Domain;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class Usuario : Entity, IAggregateRoot
    {
        public bool EmailConfirmado { get; private set; }
        public bool Ativo { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string senha)
        {
            Senha = senha;
            EmailConfirmado = false;
            Ativo = false;
        }

        //EF
        protected Usuario() { }
        public ICollection<Permissao> Permissoes { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public void AtivarConta()
        {
            EmailConfirmado = true;
            Ativo = true;
        }

        public void AdicionarHashSenha(string hash)
        {
            Senha = hash;
        }
    }

}

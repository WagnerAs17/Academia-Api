using System;

namespace AcademiaMW.Business.Models
{
    public class NovaSenhaUsuario
    {
        public Guid Id { get; private set; }
        public string Senha { get; private set; }
        public string Codigo { get; private set; }

        public NovaSenhaUsuario(Guid id, string senha, string codigo)
        {
            Id = id;
            Senha = senha;
            Codigo = codigo;
        }
    }
}

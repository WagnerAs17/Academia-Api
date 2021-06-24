using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class Cargo : Entity
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Ativo { get; private set; }

        //EF
        protected Cargo() { }
        public ICollection<Funcionario> Funcionarios { get; set; }

        public Cargo(string nome)
        {
            Nome = nome;
            Ativo = true;
            DataCriacao = DateTime.Today;
        }
    }
}

using AcademiaMW.Business.Enum;
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
        public CategoriaCargo Categoria { get; set; }

        //EF
        protected Cargo() { }
        public ICollection<Funcionario> Funcionarios { get; set; }

        public Cargo(string nome, CategoriaCargo categoria)
        {
            Nome = nome;
            Ativo = true;
            DataCriacao = DateTime.Today;
            Categoria = categoria;
        }

        public override bool EhValido()
        {
            return !string.IsNullOrEmpty(Nome) || Nome.Length <= 100;
        }
    }
}

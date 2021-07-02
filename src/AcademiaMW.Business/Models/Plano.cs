using AcademiaMW.Business.Validations;
using AcademiaMW.Core.Domain;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class Plano : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataDesativacao { get; private set; }
        public bool Ativo { get; set; }

        //EF
        protected Plano() { }
        public ICollection<PlanoValor> PlanoValores { get; set; }

        public Plano(string nome)
        {
            Nome = nome;
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public void DesativarPlano() 
        {
            DataDesativacao = DateTime.Now;
            Ativo = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new PlanoValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}

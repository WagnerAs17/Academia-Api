using AcademiaMW.Business.Validations;
using AcademiaMW.Core.Domain;
using System;

namespace AcademiaMW.Business.Models
{
    public class Aula : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime CriadoEm { get; private set; }
        protected Aula()
        {
        }

        public Aula(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = true;
            CriadoEm = DateTime.Now;
        }

        public void DesativarAula()
        {
            Ativo = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new AulaValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}

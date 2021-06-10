using AcademiaMW.Business.Validations;
using AcademiaMW.Core.Domain;
using FluentValidation.Results;
using System;

namespace AcademiaMW.Business.Models
{
    public class PlanoValor : Entity
    {
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime? DataTermino { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        //EF 
        public Plano Plano { get; set; }
        public Guid PlanoId { get; private set; }
        protected PlanoValor() { }

        public PlanoValor(decimal valor, Guid planoId, DateTime dataInicio)
        {
            Valor = valor;
            PlanoId = planoId;
            Ativo = true;
            DataInicio = dataInicio;
        }

        public override bool EhValido()
        {
            ValidationResult = new PlanoValorValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        public void DesativarValor()
        {
            Ativo = false;
            DataTermino = DateTime.Now;
        }
    }
}

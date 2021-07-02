using AcademiaMW.Business.Validations;
using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class PlanoValor : Entity
    {
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEncerramento { get; set; }
        
        public PlanoValor(decimal valor, Plano plano)
        {
            Plano = plano;
            Valor = valor;
            Ativo = true;
            DataCriacao = DateTime.Now;
        }

        public void DesativarValor()
        {
            Ativo = false;
            DataEncerramento = DateTime.Now;
        }

        public override bool EhValido()
        {
            ValidationResult = new PlanoValorValidation().Validate(this);

            return ValidationResult.IsValid && Plano.EhValido();
        }

        //EF
        protected PlanoValor() { }
        public Plano Plano { get; set; }
        public Guid PlanoId { get; set; }
        public ICollection<PlanoDesconto> PlanoDescontos { get; set; }
    }
}

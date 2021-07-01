using AcademiaMW.Core.Domain;
using System;

namespace AcademiaMW.Business.Models
{
    public class Contrato : Entity
    {
        public DateTime DataAquisicao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public bool Ativo { get; private set; }

        //EF 
        public PlanoDesconto PlanoDesconto { get; set; }
        public Guid PlanoDescontoId { get; set; }
        protected Contrato() { }

        public Contrato(PlanoDesconto desconto)
        {
            PlanoDescontoId = desconto.Id;
            DataAquisicao = DateTime.Today;
            DataVencimento = DateTime.Today.AddMonths(desconto.QuantidadeMeses);
            Ativo = true;
        }


        public decimal CalcularValorPlano()
        {
            return PlanoDesconto.Plano.Valor - (PlanoDesconto.Plano.Valor * PlanoDesconto.Percentual / 100);
        }

        public bool ContratoValido()
        {
            return DateTime.Today <= DataVencimento && Ativo;
        }

        public void EncerrarContrato()
        {
            Ativo = false;
        }

    }
}

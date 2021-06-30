using AcademiaMW.Business.Enum;
using AcademiaMW.Core.Domain;
using System;

namespace AcademiaMW.Business.Models
{
    public class Contrato : Entity
    {
        public DateTime DataAquisicao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public decimal Percentual { get; private set; }
        public bool Ativo { get; private set; }

        //EF 
        public PlanoDesconto PlanoDesconto { get; set; }
        public Guid PlanoDescontoId { get; set; }
        protected Contrato() { }

        public Contrato(Guid planoDescontoId, int tempoContrato, decimal percentual)
        {
            PlanoDescontoId = planoDescontoId;
            Percentual = percentual;
            DataAquisicao = DateTime.Today;
            DataVencimento = DateTime.Today.AddMonths(tempoContrato);
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

using AcademiaMW.Business.Enum;
using AcademiaMW.Core.Domain;
using System;

namespace AcademiaMW.Business.Models
{
    public class Contrato : Entity
    {
        public DateTime DataAquisicao { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public TempoContrato TempoContrato { get; set; }
        public decimal Percentual { get; private set; }
        public bool Ativo { get; private set; }

        //EF 
        public Plano Plano { get; set; }
        public Guid PlanoId { get; set; }

        public Contrato(Guid planoId, TempoContrato tempoContrato, decimal percentual)
        {
            PlanoId = planoId;
            Percentual = percentual;
            TempoContrato = tempoContrato;
            DataAquisicao = DateTime.Today;
            DataVencimento = DateTime.Today.AddMonths((int)tempoContrato);
            Ativo = true;
        }

        public decimal CalcularValorPlano()
        {
            return Plano.Valor - (Plano.Valor * Percentual / 100);
        }

        public bool ContratoValido()
        {
            return DataVencimento <= DateTime.Today;
        }

        public void EncerrarContrato()
        {
            Ativo = false;
        }

    }
}

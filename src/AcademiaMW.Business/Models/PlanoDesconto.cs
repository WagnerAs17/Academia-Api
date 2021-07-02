using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class PlanoDesconto : Entity
    {
        public bool Ativo { get; private set; }
        public decimal Percentual { get; private set; }
        public int QuantidadeMeses { get; private set; }
        public DateTime DataCriacao { get; private set; }

        //EF
        public PlanoValor PlanoValor { get; set; }
        public Guid PlanoValorId { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        protected PlanoDesconto()
        {}

        public PlanoDesconto(decimal percentual, int quantidadeMeses)
        {
            Percentual = percentual;
            QuantidadeMeses = quantidadeMeses;
            Ativo = true;
            DataCriacao = DateTime.Today;
        }

        public void DesativarDesconto()
        {
            Ativo = false;
        }

        public override bool EhValido()
        {
            return QuantidadeMeses >= 1;
        }

        public void AdicionarValor(PlanoValor planoValor)
        {
            PlanoValor = planoValor;
        }
    }
}

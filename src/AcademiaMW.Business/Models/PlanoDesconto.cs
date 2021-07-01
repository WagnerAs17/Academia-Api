using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class PlanoDesconto : Entity
    {
        public bool Ativo { get; set; }
        public decimal Percentual { get; set; }
        public int QuantidadeMeses { get; set; }

        //EF
        public Plano Plano { get; set; }
        public Guid PlanoId { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        protected PlanoDesconto()
        {}

        public PlanoDesconto(Guid planoId, int quantidadeMeses)
        {
            PlanoId = planoId;
            QuantidadeMeses = quantidadeMeses;
            Ativo = true;
        }
    }
}

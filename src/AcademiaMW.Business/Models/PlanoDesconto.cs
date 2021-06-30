using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class PlanoDesconto : Entity
    {
        public decimal Percentual { get; set; }
        public bool Ativo { get; set; }
        //EF
        public Plano Plano { get; set; }
        public Guid PlanoId { get; set; }
        public int QuantidadeMeses { get; set; }
        public ICollection<Contrato> Contratos { get; set; }
        protected PlanoDesconto()
        {

        }
    }
}

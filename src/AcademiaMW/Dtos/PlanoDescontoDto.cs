using System;

namespace AcademiaMW.Dtos
{
    public class PlanoDescontoDto
    {
        public Guid PlanoId { get; set; }
        public decimal Percentual { get; set; }
        public int QuantidadeMeses { get; set; }
    }
}

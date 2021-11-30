using System;

namespace AcademiaMW.Dtos
{
    public class PlanoRegistradoDto
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public Guid Id { get; set; }
        public int QuantidadeMeses { get; set; }
    }
}

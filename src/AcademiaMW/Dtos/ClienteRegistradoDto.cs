using System;

namespace AcademiaMW.Dtos
{
    public class ClienteRegistradoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Plano { get; set; }
        public decimal Valor { get; set; }
        public DateTime VencimentoContrato { get; set; }
        public string Email { get; set; }

    }
}

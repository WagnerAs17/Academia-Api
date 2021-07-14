using System;

namespace AcademiaMW.Dtos
{
    public class CargoRegistradoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public CargoRegistradoDto(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}

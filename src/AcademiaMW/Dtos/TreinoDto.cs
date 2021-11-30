using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademiaMW.Dtos
{
    public class TreinoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} deve ter {1} caracteres", MinimumLength = 10)]
        public string Nome { get; set; }
        [StringLength(1000, ErrorMessage = "O campo {0} deve ter {1} caracteres", MinimumLength = 10)]
        public string Descricao { get; set; }
        public List<TreinoItemDto> TreinoItens { get; set; }

    }
}

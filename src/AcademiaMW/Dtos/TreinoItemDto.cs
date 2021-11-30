using System.ComponentModel.DataAnnotations;

namespace AcademiaMW.Dtos
{
    public class TreinoItemDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} deve ter {1} caracteres", MinimumLength = 10)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Repeticao { get; set; }

    }
}

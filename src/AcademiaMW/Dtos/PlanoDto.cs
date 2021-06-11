using System.ComponentModel.DataAnnotations;

namespace AcademiaMW.Dtos
{
    public class PlanoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

    }
}

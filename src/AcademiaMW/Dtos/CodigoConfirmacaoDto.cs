using System.ComponentModel.DataAnnotations;

namespace AcademiaMW.Dtos
{
    public class CodigoConfirmacaoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
    }
}

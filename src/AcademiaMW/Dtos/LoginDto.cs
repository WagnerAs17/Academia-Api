using System.ComponentModel.DataAnnotations;

namespace AcademiaMW.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage =  "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
    }
}

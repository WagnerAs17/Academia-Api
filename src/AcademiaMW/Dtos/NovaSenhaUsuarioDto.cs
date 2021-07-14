using System;
using System.ComponentModel.DataAnnotations;

namespace AcademiaMW.Dtos
{
    public class NovaSenhaUsuarioDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string SenhaConfirmacao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Codigo { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace AcademiaMW.Dtos
{
    public class UsuarioConfirmacaoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Codigo { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace AcademiaMW.Dtos
{
    public class PerfilDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Nome { get; set; }
    }
}

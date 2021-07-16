using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademiaMW.Dtos
{
    public class PerfilPermissaoDto
    {
        public IEnumerable<PermissaoDto> Permissoes { get; set; }
    }

    public class PermissaoDto
    {
        [Required(ErrorMessage =  "O campo tipo é obrigatório")]
        public string Type { get; set; }

        [Required(ErrorMessage = "O campo tipo é obrigatório")]
        public string Value { get; set; }
    }
}

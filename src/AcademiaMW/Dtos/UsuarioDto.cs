using System;

namespace AcademiaMW.DTO
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int TipoUsuario { get; set; }
    }

    public class UsuarioCadastradoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int TipoUsuario { get; set; }
    }

    public class PermissaoDTO
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}

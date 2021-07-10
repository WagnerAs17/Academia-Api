using System;

namespace AcademiaMW.Dtos
{
    public class UsuarioResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public UsuarioResponseDto(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}

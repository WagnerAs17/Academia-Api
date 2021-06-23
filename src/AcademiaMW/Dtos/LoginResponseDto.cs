using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace AcademiaMW.Dtos
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenDto UsuarioToken { get; set; }

    }

    public class UsuarioTokenDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimDto> Claims { get; set; }
    }

    public class ClaimDto
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public ClaimDto(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}

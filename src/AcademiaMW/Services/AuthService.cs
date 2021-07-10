using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using AcademiaMW.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AcademiaMW.Services
{
    public class AuthService
    {
        private readonly AppSettings _settings;

        public AuthService(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public LoginResponseDto ObterResponseToken(UsuarioResponseDto usuario)
        {
            var identityClaims = ObterClaims(usuario);

            var encondedToken = GerarEncodedToken(identityClaims);

            return new LoginResponseDto
            {
                AccessToken = encondedToken,
                ExpiresIn = TimeSpan.FromHours(_settings.ExpiracaoHoras).TotalSeconds,
                UsuarioToken = new UsuarioTokenDto
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Claims = identityClaims.Claims.Select(c => new ClaimDto(c.Type, c.Value))
                }
            };
        }

        private ClaimsIdentity ObterClaims(UsuarioResponseDto usuario)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, usuario.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private string GerarEncodedToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _settings.Emissor,
                Audience = _settings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_settings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}

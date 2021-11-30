using AcademiaMW.Business.Enum;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Dtos
{
    public class UsuarioResponseDto
    {
        const int CODIGO_CLIENTE = 6;
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }

        public UsuarioResponseDto(Guid id, string email)
        {
            Id = id;
            Email = email;
            Perfil = obterTipoPerfil(CODIGO_CLIENTE);
        }
        
        public UsuarioResponseDto(Guid id, string email, int codigoPerfil)
        {
            Id = id;
            Email = email;
            Perfil = obterTipoPerfil(codigoPerfil);
        }

        private string obterTipoPerfil(int codigoPerfil)
        {
            var perfis = CriarDicionarioDePerfis();

            return perfis.GetValueOrDefault(codigoPerfil);
        }

        private Dictionary<int , string> CriarDicionarioDePerfis()
        {
            var perfis = new Dictionary<int, string>();
            perfis.Add(CODIGO_CLIENTE, "Cliente");
            perfis.Add((int)CategoriaCargo.Consultor, "Consultor");
            perfis.Add((int)CategoriaCargo.Gerente, "Gerente");
            perfis.Add((int)CategoriaCargo.Instrutor, "Instrutor");
            perfis.Add((int)CategoriaCargo.Recepcionista, "Recepcionista");
            perfis.Add((int)CategoriaCargo.Supervidor, "Supervidor");

            return perfis;
        }
    }
}

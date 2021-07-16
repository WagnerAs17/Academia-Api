using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Mapper
{
    public static class PerfilMapper
    {
        public static IEnumerable<PerfilPermissao> PerfilPermissoesDtoParaPerfilPermissao(this PerfilPermissaoDto perfilPermissaoDto, Guid perfilId)
        {
            var perfilPermissoes = new List<PerfilPermissao>();

            foreach (var perfilPermissao in perfilPermissaoDto.Permissoes)
            {
                perfilPermissoes.Add(new PerfilPermissao(perfilId, perfilPermissao.Type, perfilPermissao.Value));
            }

            return perfilPermissoes;
        }
    }
}

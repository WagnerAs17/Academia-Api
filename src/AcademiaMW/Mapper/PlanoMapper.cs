using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using System.Collections.Generic;

namespace AcademiaMW.Mapper
{
    public class PlanoMapper
    {
        public static Paginated<PlanoRegistradoDto> PaginatedPlanosParaPlanoDto(Paginated<Plano> paginated)
        {
            return new Paginated<PlanoRegistradoDto>
            {
                TotalPages = paginated.TotalPages,
                PageIndex = paginated.PageIndex,
                HasPreviousPage = paginated.HasPreviousPage,
                HasNextPage = paginated.HasNextPage,
                Data = PlanosParaPlanosDto(paginated.Data)
            };
        }

        private static IEnumerable<PlanoRegistradoDto> PlanosParaPlanosDto(IEnumerable<Plano> planos)
        {
            var listaPlanos = new List<PlanoRegistradoDto>();

            foreach (var plano in planos)
            {
                listaPlanos.Add(new PlanoRegistradoDto { Id = plano.Id, Nome = plano.Nome, Valor = plano.Valor });
            }

            return listaPlanos;
        }
    }
}

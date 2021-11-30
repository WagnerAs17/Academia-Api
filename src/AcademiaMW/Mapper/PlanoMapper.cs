using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using System.Collections.Generic;
using System.Linq;

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
                var planoDesconto = plano.PlanoValores.SelectMany(x => x.PlanoDescontos);

                var valor = plano.PlanoValores.FirstOrDefault(x => x.Ativo).Valor;
                var desconto =  planoDesconto.Any() ? planoDesconto.FirstOrDefault(x => x.Ativo).Percentual : 0;
                var quantidadeMeses = planoDesconto.Any() ? planoDesconto.FirstOrDefault(x => x.Ativo).QuantidadeMeses : 0;

                listaPlanos.Add(new PlanoRegistradoDto
                {
                    Id = plano.Id,
                    Nome = plano.Nome,
                    Valor = valor,
                    Desconto = desconto,
                    QuantidadeMeses = quantidadeMeses
                });
            }

            return listaPlanos;
        }

        public static PlanoDesconto PlanoDescontoDtoParaPlanoDesconto(PlanoDescontoDto desconto)
        {
            return new PlanoDesconto(desconto.Percentual, desconto.QuantidadeMeses);
        }
    }
}

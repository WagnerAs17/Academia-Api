using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using System.Collections.Generic;

namespace AcademiaMW.Mapper
{
    public static class TreinoMapper
    {
        public static Treino TreinoDtoToTreino(Cliente cliente,TreinoDto treinoDto)
        {
            return new Treino(cliente.Id, treinoDto.Nome, treinoDto.Descricao);
        }

        public static List<TreinoItem> TreinoItensDtoToTreinoItens(Treino treino, List<TreinoItemDto> treinoItensDto)
        {
            var treinosItens = new List<TreinoItem>();
            foreach (var item in treinoItensDto)
            {
                treinosItens.Add(new TreinoItem(treino, item.Nome, item.Repeticao));
            }

            return treinosItens;
        } 
    }
}

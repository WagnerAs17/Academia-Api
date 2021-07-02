using AcademiaMW.Business.Models;
using AcademiaMW.Core.Domain;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IPlanoService : IService
    {
        Task<bool> Adicionar(PlanoValor planoValor);
        Task<Paginated<Plano>> ObterPlanosPaginados(Pagination pagination);
        Task AdicionarDescontoPlano(Guid planoId, PlanoDesconto planoDesconto);
    }
}

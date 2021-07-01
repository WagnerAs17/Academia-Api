using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        Task Adicionar(Plano plano);
        Task<Paginated<Plano>> ObterPlanos(Pagination pagination);
        Task<PlanoDesconto> ObterDescontoPlano(Guid planoId);
        Task AdicionarDesconto(PlanoDesconto desconto);
        Task<IEnumerable<PlanoDesconto>> ObterDescontoAtivos(Guid planoId);
        Task Commit();
    }
}

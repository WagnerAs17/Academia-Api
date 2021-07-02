using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        Task Adicionar(PlanoValor plano);
        Task<Paginated<Plano>> ObterPlanos(Pagination pagination);
        Task<PlanoDesconto> ObterDescontoPlano(Guid planoId);
        Task AdicionarDesconto(PlanoDesconto desconto);
        Task<IEnumerable<PlanoDesconto>> ObterDescontoAtivos(Guid planoValorId);
        Task<IEnumerable<PlanoValor>> ObterValoresAtivosPlano(Guid planoId);
        Task Commit();
        Task<bool> Existe(Expression<Func<Plano, bool>> expression);
    }
}

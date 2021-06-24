using AcademiaMW.Core.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<bool> Adicionar(Cliente cliente);
        Task<Cliente> ObterClientePorId(Guid id);
        Task<Paginated<Cliente>> ObterTodos(Pagination pagination);
        Task<bool> Existe(Expression<Func<Cliente, bool>> expression);
    }
}

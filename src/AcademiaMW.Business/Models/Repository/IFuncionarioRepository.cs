using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<bool> Contratar(Funcionario funcionario);
        Task<bool> Existe(Expression<Func<Funcionario, bool>> expression);
    }
}

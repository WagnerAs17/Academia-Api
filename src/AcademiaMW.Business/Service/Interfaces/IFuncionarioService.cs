using AcademiaMW.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IFuncionarioService : IService
    {
        Task<bool> Contratar(Funcionario funcionario);
        Task AdicionarNovoCargo(Cargo cargo);
        Task<IEnumerable<Cargo>> ObterCargos();
    }
}

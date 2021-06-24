using AcademiaMW.Business.Models;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IFuncionarioService : IService
    {
        Task<bool> Matricular(Funcionario funcionario);
    }
}

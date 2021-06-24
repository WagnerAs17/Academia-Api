using AcademiaMW.Business.Models;
using AcademiaMW.Core.Domain;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IPlanoService : IService
    {
        Task<bool> Adicionar(Plano plano);
        Task<Paginated<Plano>> ObterPlanosPaginados(Pagination pagination);
    }
}

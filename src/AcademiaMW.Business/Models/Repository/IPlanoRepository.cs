using AcademiaMW.Core.Domain;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IPlanoRepository : IRepository<Plano>
    {
        Task Adicionar(Plano plano);
        Task<Paginated<Plano>> ObterPlanos(Pagination pagination);
    }
}

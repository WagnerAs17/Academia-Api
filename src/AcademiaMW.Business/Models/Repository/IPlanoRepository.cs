using AcademiaMW.Core.Domain;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IPlanoRepository
    {
        Task Adicionar(Plano plano);
        Task<Paginated<Plano>> ObterPlanos(Pagination pagination);
    }
}

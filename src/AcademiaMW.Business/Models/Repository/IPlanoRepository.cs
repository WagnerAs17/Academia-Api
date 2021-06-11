using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IPlanoRepository
    {
        Task Adicionar(Plano plano);
    }
}

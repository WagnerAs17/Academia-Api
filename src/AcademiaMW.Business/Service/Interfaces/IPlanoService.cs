using AcademiaMW.Business.Models;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IPlanoService
    {
        Task<bool> Adicionar(Plano plano);
    }
}

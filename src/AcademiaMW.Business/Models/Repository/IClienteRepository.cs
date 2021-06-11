using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente cliente);
    }
}

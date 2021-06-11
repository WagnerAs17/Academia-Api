using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente cliente);
        Task<Cliente> ObterClientePorId(Guid id);
    }
}

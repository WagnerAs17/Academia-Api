using AcademiaMW.Business.Models;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public interface IClienteService
    {
        Task<bool> Matricular(Cliente cliente);
        Task<Cliente> ObterCliente(Guid id);
    }
}

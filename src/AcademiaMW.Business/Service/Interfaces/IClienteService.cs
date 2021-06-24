using AcademiaMW.Business.Models;
using AcademiaMW.Business.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public interface IClienteService : IService
    {
        Task<bool> Matricular(Cliente cliente);
        Task<Cliente> ObterCliente(Guid id);
    }
}

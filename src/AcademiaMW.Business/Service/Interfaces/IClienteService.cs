using AcademiaMW.Business.Models;
using AcademiaMW.Business.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public interface IClienteService : IService
    {
        Task<bool> Matricular(Cliente cliente, Guid planoId);
        Task<Cliente> ObterCliente(Guid id);
    }
}

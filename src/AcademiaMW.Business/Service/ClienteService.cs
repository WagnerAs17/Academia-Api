using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class ClienteService : Service, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService
        (
            INotificador notificador,
            IClienteRepository clienteRepository
        ): base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Matricular(Cliente cliente)
        {
            if (!cliente.EhValido())
            {
                Notificar(cliente.ValidationResult);
                return false;
            }

            await _clienteRepository.Adicionar(cliente);

            return true;
        }

        public async Task<Cliente> ObterCliente(Guid id)
        {
            return await _clienteRepository.ObterClientePorId(id);
        }
    }
}

using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class ClienteService : Service, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IBCryptPasswordHasher _passwordHash;

        public ClienteService
        (
            INotificador notificador,
            IClienteRepository clienteRepository,
            IBCryptPasswordHasher passwordHash
        ): base(notificador)
        {
            _clienteRepository = clienteRepository;
            _passwordHash = passwordHash;
        }

        public async Task<bool> Matricular(Cliente cliente)
        {
            if (!cliente.EhValido())
            {
                Notificar(cliente.ValidationResult);
                Notificar(cliente.Contrato.ValidationResult);

                return false;
            }

            if(await ClienteRegistrado(cliente))
            {
                Notificar("Cliente já registrado");
                return false;
            }

            var hash = _passwordHash.GetHashPassword(cliente.Usuario.Senha);

            cliente.Usuario.AdicionarHashSenha(hash);

            await _clienteRepository.Adicionar(cliente);

            return true;
        }

        public async Task<Cliente> ObterCliente(Guid id)
        {
            return await _clienteRepository.ObterClientePorId(id);
        }

        private Task<bool> ClienteRegistrado(Cliente cliente)
        {
            return _clienteRepository.Existe(c =>
                c.Email.Endereco.Equals(cliente.Email.Endereco)
                || c.CPF.Numero.Equals(cliente.CPF.Numero));
        }
    }
}

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
        private readonly IPlanoRepository _planoRepository;

        public ClienteService
        (
            INotificador notificador,
            IClienteRepository clienteRepository,
            IBCryptPasswordHasher passwordHash,
            IPlanoRepository planoRepository
        ): base(notificador)
        {
            _clienteRepository = clienteRepository;
            _passwordHash = passwordHash;
            _planoRepository = planoRepository;
        }

        public async Task<bool> Matricular(Cliente cliente, Guid planoId)
        {
            if (!cliente.EhValido())
            {
                Notificar(cliente.ValidationResult);

                return false;
            }

            if(await ClienteMatriculado(cliente))
            {
                Notificar("Cliente já matriculado !");
                return false;
            }

            var planoDesconto = await _planoRepository.ObterDescontoPlano(planoId);

            if (planoDesconto == null)
            {
                Notificar("Plano sem desconto associado");
                return false;
            }

            cliente.AdicionarContrato(new Contrato(planoDesconto));

            var hash = _passwordHash.GetHashPassword(cliente.Usuario.Senha);

            cliente.Usuario.AdicionarHashSenha(hash);

            return await _clienteRepository.Adicionar(cliente);
        }

        public async Task<Cliente> ObterCliente(Guid id)
        {
            return await _clienteRepository.ObterClientePorId(id);
        }

        private Task<bool> ClienteMatriculado(Cliente cliente)
        {
            return _clienteRepository.Existe(c =>
                c.Email.Endereco.Equals(cliente.Email.Endereco)
                || c.CPF.Numero.Equals(cliente.CPF.Numero));
        }
    }
}

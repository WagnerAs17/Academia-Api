using AcademiaMW.Business.Events;
using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using AcademiaMW.Core.Communication.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class ClienteService : Service, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IBCryptPasswordHasher _passwordHash;
        private readonly IPlanoRepository _planoRepository;
        private readonly IMediatorHandler _mediator;

        public ClienteService
        (
            INotificador notificador,
            IClienteRepository clienteRepository,
            IBCryptPasswordHasher passwordHash,
            IPlanoRepository planoRepository,
            IMediatorHandler mediatorHandler
        ): base(notificador)
        {
            _clienteRepository = clienteRepository;
            _passwordHash = passwordHash;
            _planoRepository = planoRepository;
            _mediator = mediatorHandler;
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

            if (await _clienteRepository.Adicionar(cliente))
                await _mediator.PublicarEvento(
                    new CodigoConfirmacaoEvent(cliente.Usuario.Id, cliente.Email.Endereco, cliente.Nome));

            return true;
        }

        public async Task<bool> AdicionarTreinoItens(Treino treino, List<TreinoItem> treinoItens)
        {
            if (!treino.EhValido())
            {
                Notificar("O nome do treino é obrigatório");
            }

            foreach (var item in treinoItens)
            {
                if (!item.EhValido())
                {
                    Notificar($"{item.Nome}: o nome deve é obrigatório e deve ter ao menos uma repetição");
                }
            }

            return await _clienteRepository.AdicionarTreinoItens(treinoItens);
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

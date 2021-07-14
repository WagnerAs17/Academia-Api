using AcademiaMW.Business.Events;
using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Core.Communication.Mediator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class FuncionarioService : Service, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IBCryptPasswordHasher _passwordHash;
        public FuncionarioService
        (
            IFuncionarioRepository funcionarioRepository,
            INotificador notificador,
            IMediatorHandler mediatorHandler,
            IBCryptPasswordHasher passwordHash
        ) : base(notificador)
        {
            _funcionarioRepository = funcionarioRepository;
            _mediatorHandler = mediatorHandler;
            _passwordHash = passwordHash;
        }

        public async Task<IEnumerable<Cargo>> ObterCargos()
        {
            return await _funcionarioRepository.ObterCargos();
        }
        public async Task<bool> Contratar(Funcionario funcionario)
        {
            if (!funcionario.EhValido())
            {
                Notificar(funcionario.ValidationResult);
                return false;
            }

            var cargo = await _funcionarioRepository.ObterCargoPorId(funcionario.CargoId);
            if (cargo == null)
            {
                Notificar("Cargo informado inválido");
                return false;
            }

            if(await FuncionarioContratado(funcionario))
            {
                Notificar($"{funcionario.Nome} já faz parte do quadro de funcionários");
                return false;
            }

            var senhaAutomatica = funcionario.Usuario.Senha;

            var hash = _passwordHash.GetHashPassword(senhaAutomatica);

            funcionario.Usuario.AdicionarHashSenha(hash);

            if (await _funcionarioRepository.Contratar(funcionario))
            {
                await _mediatorHandler.PublicarEvento(
                    new NovoFuncionarioEvent(funcionario.Email.Endereco, funcionario.Nome, senhaAutomatica));

                return true;
            }

            Notificar("Erro ao contratar novo funcionário");

            return false;
        }

        public async Task AdicionarNovoCargo(Cargo cargo)
        {
            if (!cargo.EhValido())
            {
                Notificar("O nome do cargo é obrigatório");
                return;
            }

            if(!await _funcionarioRepository.NovoCargo(cargo))
                Notificar("Um erro ocorreu");
        }

        private async Task<bool> FuncionarioContratado(Funcionario funcionario)
        {
            return await _funcionarioRepository.Existe(f =>
                f.CPF.Numero.Equals(funcionario.CPF.Numero) ||
                f.Email.Endereco.Equals(funcionario.Email.Endereco));
        }
    }
}

using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service.Interfaces;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class FuncionarioService : Service, IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService
        (
            IFuncionarioRepository funcionarioRepository,
            INotificador notificador
        ) : base(notificador)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<bool> Contratar(Funcionario funcionario)
        {
            if (!funcionario.EhValido())
            {
                Notificar(funcionario.ValidationResult);
                return false;
            }

            if(await FuncionarioContratado(funcionario))
            {
                Notificar($"{funcionario.Nome} já faz parte do quadro de funcionários");
                return false;
            }

            return await _funcionarioRepository.Contratar(funcionario);
        }

        private async Task<bool> FuncionarioContratado(Funcionario funcionario)
        {
            return await _funcionarioRepository.Existe(f =>
                f.CPF.Numero.Equals(funcionario.CPF.Numero) ||
                f.Email.Endereco.Equals(funcionario.Email.Endereco));
        }
    }
}

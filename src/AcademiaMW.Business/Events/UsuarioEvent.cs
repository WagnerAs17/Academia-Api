using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Core.Domain;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Events
{
    public class UsuarioEvent : INotificationHandler<CodigoConfirmacaoEvent>, INotificationHandler<NovoFuncionarioEvent>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailService _emailService;

        public UsuarioEvent
        (
            IUsuarioRepository usuarioRepository,
            IEmailService emailService
        )
        {
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
        }
        public async Task Handle(CodigoConfirmacaoEvent message, CancellationToken cancellationToken)
        {
            var result = await _usuarioRepository
                .AdicionarConfirmacaoUsuario(message.UsuarioConfirmacao);

            if (result)
            {
                var titulo = $"Seja bem-vindo {message.NomeUsuario}";
                var mensagem = $"Código de confirmação: {message.UsuarioConfirmacao.Codigo}";

                var email = new Email(titulo, message.Email, mensagem);
                await _emailService.EnviarEmail(email);
            }
        }

        public async Task Handle(NovoFuncionarioEvent message, CancellationToken cancellationToken)
        {
            var titulo = $"{message.NomeUsuario} Seja-bem vindo!";
            var sb = new StringBuilder();

            sb.Append($"{message.NomeUsuario}, \n");
            sb.Append("Estamos muito feliz por fazer parte do sistema Olimpo ");
            sb.Append($"Sua senha: {message.Senha}");

            var email = new Email(titulo, message.Email, sb.ToString());

            await _emailService.EnviarEmail(email);
        }
    }
}

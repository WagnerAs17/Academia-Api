using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Core.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Events
{
    public class UsuarioEvent : INotificationHandler<CodigoConfirmacaoEvent>
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
    }
}

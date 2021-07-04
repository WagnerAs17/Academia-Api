using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Controllers;
using AcademiaMW.Dtos;
using AcademiaMW.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AcademiaMW.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contas")]
    public class ContaController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly AuthService _authService;

        public ContaController
        (
            INotificador notificador,
            IUsuarioService usuarioService,
            AuthService authService
        ) : base(notificador)
        {
            _usuarioService = usuarioService;
            _authService = authService;
        }

        [HttpPost("autenticar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var cliente = await _usuarioService.AutenticarCliente(login.Email, login.Senha);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            return CustomResponse(_authService.ObterResponseToken(cliente));
        }

        [HttpPost("confirmar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmarConta([FromBody] UsuarioConfirmacaoDto usuarioConfirmacao)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _usuarioService.ConfirmarConta(usuarioConfirmacao.Id, usuarioConfirmacao.Codigo);

            return CustomResponse();
        }


    }
}

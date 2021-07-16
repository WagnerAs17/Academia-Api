using AcademiaMW.Business.Models;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Controllers;
using AcademiaMW.Dtos;
using AcademiaMW.Mapper;
using AcademiaMW.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaMW.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contas")]
    public class ContaController : MainController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IContaService _contaService;
        private readonly AuthService _authService;

        public ContaController
        (
            INotificador notificador,
            IUsuarioService usuarioService,
            IContaService contaService,
            AuthService authService
        ) : base(notificador)
        {
            _usuarioService = usuarioService;
            _contaService = contaService;
            _authService = authService;
        }

        [HttpPost("autenticar/cliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginCliente([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var cliente = await _contaService.AutenticarCliente(login.Email, login.Senha);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            return CustomResponse(await _authService.ObterResponseToken(new UsuarioResponseDto(cliente.Usuario.Id, cliente.Email.Endereco)));
        }

        [HttpPost("autenticar/funcionario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginFuncionario([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var result = await _contaService.AutenticarFuncionario(login.Email, login.Senha);

            if (!OperacaoValida())
            {
                return CustomResponse();
            }

            if (result.PrimeiroAcesso)
                return CustomResponse(new { Id = result.Value.Usuario.Id, PrimeiroAcesso = result.PrimeiroAcesso });

            return CustomResponse(await _authService.ObterResponseToken(new UsuarioResponseDto(result.Value.Usuario.Id, result.Value.Email.Endereco)));
        }

        [HttpPost("confirmar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmarConta([FromBody] UsuarioConfirmacaoDto usuarioConfirmacao)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _contaService.ConfirmarConta(usuarioConfirmacao.Id, usuarioConfirmacao.Codigo);

            return CustomResponse();
        }

        [HttpPost("codigo-confirmacao")]
        public async Task<IActionResult> GerarNovoCodigo([FromBody] CodigoConfirmacaoDto confirmacaoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuarioId = await _usuarioService.GerarNovoCodigoConfirmacao(confirmacaoDto.Email);

            return CustomResponse(new { Id = usuarioId });
        }

        [HttpPost("nova-senha")]
        public async Task<IActionResult> ResetarSenha([FromBody] NovaSenhaUsuarioDto novaSenhaUsuarioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!_contaService.SenhaForte(novaSenhaUsuarioDto.Senha))
                return CustomResponse();

            await _contaService.ResetarSenha(
                new NovaSenhaUsuario(novaSenhaUsuarioDto.Id, novaSenhaUsuarioDto.Senha, novaSenhaUsuarioDto.Codigo));

            return CustomResponse("Nova senha adicionada com sucesso !");
        }

        [HttpPost("perfil")]
        public async Task<IActionResult> AdicionarPerfil([FromBody] PerfilDto perfil)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _usuarioService.AdicionarPerfil(new Perfil(perfil.Nome));

            return CustomResponse();
        }

        [HttpPost("perfil/{id:guid}/permissoes")]
        public async Task<IActionResult> AdicionarPermissaoPerfil([FromRoute] Guid id, [FromBody] PerfilPermissaoDto perfilPermissoes)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _usuarioService.AdicionarPermissaoPerfil(perfilPermissoes.PerfilPermissoesDtoParaPerfilPermissao(id));

            return CustomResponse();
        }

        [HttpPost("usuario/{id:guid}/perfil")]
        public async Task<IActionResult> AdicionarPerfilUsuario([FromRoute] Guid id, [FromBody] UsuarioPerfilDto usuarioPerfil)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _usuarioService.AdicionarPerfilUsuario(new UsuarioPerfil(usuarioPerfil.PerfilId, id));

            return CustomResponse();
        }

    }
}

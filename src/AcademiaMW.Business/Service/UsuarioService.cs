using AcademiaMW.Business.Extensions;
using AcademiaMW.Business.Helpers;
using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class UsuarioService : Service, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IBCryptPasswordHasher _bcrypt;
        private readonly IEmailService _emailService;

        public UsuarioService
        (
            IUsuarioRepository usuarioRepository,
            IBCryptPasswordHasher bcrypt,
            INotificador notificador,
            IEmailService emailService
        ) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _bcrypt = bcrypt;
            _emailService = emailService;
        }

        public Usuario GerarNovoUsuarioFuncionario()
        {
            return new Usuario(PasswordHelper.GerarSenhaAutomatica());
        }

        public Usuario GerarNovoUsuarioCliente(string senha)
        {
            return new Usuario(senha);
        }

        public async Task<Guid> GerarNovoCodigoConfirmacao(string enderecoEmail)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorEmail(enderecoEmail);

            if(usuario == null)
            {
                Notificar("Um erro aconteceu, verique o e-mail e tente novamente");
                return Guid.Empty;
            }

            await DesativarCodigosAtivoUsuario(usuario.Id);

            var confirmacaoUsuario = new UsuarioConfirmacao(usuario.Id);

            var resultado = await _usuarioRepository.AdicionarConfirmacaoUsuario(confirmacaoUsuario);

            if (resultado)
            {
                var mensagemCodigoEnvio = confirmacaoUsuario.Codigo.ObterMensagemEmailEnvioCodigo();

                var email = new Email(mensagemCodigoEnvio.titulo, enderecoEmail, mensagemCodigoEnvio.mensagem);

                await _emailService.EnviarEmail(email);
            }

            return usuario.Id;
        }
        
        public async Task AdicionarPerfil(Perfil perfil)
        {
            if (!perfil.EhValido())
            {
                Notificar("O nome é obrigatório");
                return;
            }

            await _usuarioRepository.AdicionarPerfil(perfil);
        }

        public async Task AdicionarPermissaoPerfil(IEnumerable<PerfilPermissao> perfilPermissoes)
        {
            var permissoesValidas = perfilPermissoes.Select(perfilPermissao => perfilPermissao.EhValido());

            if (permissoesValidas.Any(valido => !valido))
            {
                Notificar("Tipo e valor da permissão são obrigatórios");
                return;
            }

            await _usuarioRepository.AdicionarPermissoesPerfil(perfilPermissoes);
        }

        public async Task AdicionarPerfilUsuario(UsuarioPerfil usuarioPerfil)
        {
            if(!await PerfilExiste(usuarioPerfil.PerfilId))
            {
                Notificar("Perfil informado inválido");
                return;
            }

            if(!await UsuarioExiste(usuarioPerfil.UsuarioId))
            {
                Notificar("Usuario informado inválido");
                return;
            }

            await _usuarioRepository.AdicionarPerfilUsuario(usuarioPerfil);
        }

        private async Task DesativarCodigosAtivoUsuario(Guid usuarioId)
        {
            var codigosAtivoUsuarios = await _usuarioRepository.ObterCodigosAtivosUsuario(usuarioId);

            foreach (var codigoAtivo in codigosAtivoUsuarios)
            {
                codigoAtivo.DesativarCodigoConfirmacao();
            }

            await _usuarioRepository.DesativarCodigosAtivoUsuario(codigosAtivoUsuarios);
        }

        private async Task<bool> PerfilExiste(Guid id)
        {
            return await _usuarioRepository.Existe<Perfil>(x => x.Id == id);
        }

        private async Task<bool> UsuarioExiste(Guid id)
        {
            return await _usuarioRepository.Existe<Usuario>(x => x.Id == id);
        }

    }
}

using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using AcademiaMW.Business.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class UsuarioService : Service, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IBCryptPasswordHasher _bcrypt;

        public UsuarioService
        (
            IUsuarioRepository usuarioRepository,
            IBCryptPasswordHasher bcrypt,
            INotificador notificador
        ) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _bcrypt = bcrypt;
        }

        public async Task<Cliente> AutenticarCliente(string email, string senha)
        {
            var cliente = await _usuarioRepository.ObterCliente(email);

            if (cliente == null || !_bcrypt.VerifyHash(senha, cliente.Usuario.Senha))
            {
                Notificar("E-mail ou senha incorreto!");

                return null;
            }

            if(!cliente.Usuario.Ativo || cliente.Usuario.EmailConfirmado)
            {
                Notificar("E-mail não confirmado, favor solicitar confirmação");

                return null;
            }

            return cliente;
        }

        public async Task ConfirmarConta(Guid usuarioId, string codigo)
        {
            var usuarioConfirmacao = await _usuarioRepository.ObterConfirmacaoUsuario(usuarioId);

            if (usuarioConfirmacao == null)
            {
                Notificar("Código inválido");
                return;
            }

            if (!usuarioConfirmacao.CodigoValido())
            {
                await AplicarValidacao(usuarioConfirmacao);
                return;
            }

            if (codigo != usuarioConfirmacao.Codigo)
            {
                await AplicarValidacao(usuarioConfirmacao);
                return;
            }

            usuarioConfirmacao.DesativarCodigoConfirmacao();
            _usuarioRepository.AtualizarConfirmacaoUsuario(usuarioConfirmacao);
            
            var usuario = await _usuarioRepository.ObterUsuarioPorId(usuarioId);
            usuario.AtivarConta();
            _usuarioRepository.AtualizarUsuario(usuario);

            if (!await _usuarioRepository.Commit())
                Notificar("Um erro ocorreu para confirmar a conta");
        }

        private async Task AplicarValidacao(UsuarioConfirmacao usuarioConfirmacao)
        {
            Notificar("Código de confirmação não é válido");
            usuarioConfirmacao.DesativarCodigoConfirmacao();
            _usuarioRepository.AtualizarConfirmacaoUsuario(usuarioConfirmacao);
            await _usuarioRepository.Commit();
        }

    }
}

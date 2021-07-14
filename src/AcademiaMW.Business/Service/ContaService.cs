using AcademiaMW.Business.Events;
using AcademiaMW.Business.Helpers;
using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Core.Communication.Mediator;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class ContaService : Service, IContaService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IBCryptPasswordHasher _bcrypt;

        public ContaService
        (
            INotificador notificador,
            IUsuarioRepository usuarioService,
            IMediatorHandler mediatorHandler,
            IBCryptPasswordHasher bcrypt
        ) : base(notificador)
        {
            _usuarioRepository = usuarioService;
            _mediatorHandler = mediatorHandler;
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

            if (!ContaClienteConfirmada(cliente))
            {
                Notificar("E-mail não confirmado, favor solicitar confirmação");
            }

            return cliente;
        }

        public async Task<Result<Funcionario>> AutenticarFuncionario(string email, string senha)
        {
            var funcionario = await _usuarioRepository.ObterFuncionario(email);

            if (funcionario == null || !_bcrypt.VerifyHash(senha, funcionario.Usuario.Senha))
            {
                Notificar("E-mail ou senha incorreto!");
                return null;
            }

            if (PrimeiroAcessoFuncionario(funcionario))
            {
                await _mediatorHandler
                    .PublicarEvento(new CodigoConfirmacaoEvent(funcionario.UsuarioId, email, funcionario.Nome));

                return new Result<Funcionario>(funcionario, true);
            }

            return new Result<Funcionario>(funcionario, false);
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

            var usuario = await _usuarioRepository.ObterUsuarioPorId(usuarioId);
            AtualizarInformacoesUsuario(usuario, usuarioConfirmacao);

            if (!await _usuarioRepository.Commit())
                Notificar("Um erro ocorreu para confirmar a conta");
        }

        public async Task<bool> ResetarSenha(NovaSenhaUsuario novaSenhaUsuario)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorId(novaSenhaUsuario.Id);
            if (usuario == null)
            {
                Notificar("Usuario inválido");
                return false;
            }

            var codigoConfirmacao = await _usuarioRepository.ObterConfirmacaoUsuario(usuario.Id);
            if (codigoConfirmacao == null)
            {
                Notificar("Código de confirmação inválido");
                return false;
            }

            if (!codigoConfirmacao.CodigoValido() || codigoConfirmacao.Codigo != novaSenhaUsuario.Codigo)
            {
                await AplicarValidacao(codigoConfirmacao);
                return false;
            }

            AtualizarInformacoesUsuario(usuario, codigoConfirmacao);

            var hash = _bcrypt.GetHashPassword(novaSenhaUsuario.Senha);

            usuario.AdicionarHashSenha(hash);

            await _usuarioRepository.Commit();

            return true;
        }

        public bool SenhaForte(string senha)
        {
            var valido = true;

            for (int index = 0; index < PasswordHelper.RandomChars.Length; index++)
            {
                if (!PasswordHelper.RandomChars[index].Any(c => senha.Contains(c)))
                {
                    Notificar(PasswordHelper.ValidationMessages[index]);
                    valido = false;
                }
            }

            return valido;
        }

        private bool ContaClienteConfirmada(Cliente cliente)
        {
            return !cliente.Usuario.Ativo || !cliente.Usuario.EmailConfirmado;
        }
        private bool PrimeiroAcessoFuncionario(Funcionario funcionario)
        {
            return !funcionario.Usuario.Ativo && !funcionario.Usuario.EmailConfirmado;
        }

        private async Task AplicarValidacao(UsuarioConfirmacao usuarioConfirmacao)
        {
            Notificar("Código de confirmação não é válido, solicite um novo código");
            usuarioConfirmacao.DesativarCodigoConfirmacao();
            _usuarioRepository.AtualizarConfirmacaoUsuario(usuarioConfirmacao);
            await _usuarioRepository.Commit();
        }

        private void AtualizarInformacoesUsuario(Usuario usuario, UsuarioConfirmacao usuarioConfirmacao)
        {
            usuario.AtivarConta();
            _usuarioRepository.AtualizarUsuario(usuario);

            usuarioConfirmacao.DesativarCodigoConfirmacao();
            _usuarioRepository.AtualizarConfirmacaoUsuario(usuarioConfirmacao);
        }
    }
}

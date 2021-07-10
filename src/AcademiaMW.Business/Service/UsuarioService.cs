using AcademiaMW.Business.Helpers;
using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using AcademiaMW.Business.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class UsuarioService : Service, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IBCryptPasswordHasher _bcrypt;
        private const int tamanhoSenha = 8;

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

            if (!cliente.Usuario.Ativo || !cliente.Usuario.EmailConfirmado)
            {
                Notificar("E-mail não confirmado, favor solicitar confirmação");

                return null;
            }

            return cliente;
        }

        public async Task<Funcionario> AutenticarFuncionario(string email, string senha)
        {
            var funcionario = await _usuarioRepository.ObterFuncionario(email);

            if(funcionario == null || !_bcrypt.VerifyHash(senha, funcionario.Usuario.Senha))
            {
                Notificar("E-mail ou senha incorreto!");
                return null;
            }

            return funcionario;
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
            usuario.AtivarConta();
            _usuarioRepository.AtualizarUsuario(usuario);

            usuarioConfirmacao.DesativarCodigoConfirmacao();
            _usuarioRepository.AtualizarConfirmacaoUsuario(usuarioConfirmacao);

            if (!await _usuarioRepository.Commit())
                Notificar("Um erro ocorreu para confirmar a conta");
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

        public Usuario GerarNovoUsuarioFuncionario()
        {
            return new Usuario(GerarSenhaAutomatica());
        }

        public Usuario GerarNovoUsuarioCliente(string senha)
        {
            return new Usuario(senha);
        }

        private async Task AplicarValidacao(UsuarioConfirmacao usuarioConfirmacao)
        {
            Notificar("Código de confirmação não é válido");
            usuarioConfirmacao.DesativarCodigoConfirmacao();
            _usuarioRepository.AtualizarConfirmacaoUsuario(usuarioConfirmacao);
            await _usuarioRepository.Commit();
        }

        private string GerarSenhaAutomatica()
        {
            var chars = new List<char>();
            var random = new Random(Environment.TickCount);
            
            for (int position = 0; position < PasswordHelper.RandomChars.Length; position++)
            {
                InsertStrongPasswordCharacteristic(chars, random, position);
            }

            for (int index = chars.Count; index < tamanhoSenha
                || chars.Distinct().Count() < 1; index++)
            {
                string rcs = PasswordHelper.RandomChars[random.Next(0, PasswordHelper.RandomChars.Length)];
                chars.Insert(random.Next(0, chars.Count),
                    rcs[random.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        private void InsertStrongPasswordCharacteristic(List<char> chars, Random random, int position) 
        {
            chars.Insert(random.Next(0, chars.Count),
                       PasswordHelper.RandomChars[position]
                       [random.Next(0, PasswordHelper.RandomChars[position].Length)]);
        }

    }
}

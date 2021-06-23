using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Security;
using AcademiaMW.Business.Service.Interfaces;
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

            return cliente;
        }

    }
}

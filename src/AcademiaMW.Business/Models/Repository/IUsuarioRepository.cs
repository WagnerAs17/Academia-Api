using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task AdicionarAsync(Usuario usuario);
        Task<Cliente> ObterCliente(string email);
        Task<Funcionario> ObterFuncionario(string email);
        void RemoverUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        Task<IEnumerable<Usuario>> ObterTodos();
        Task<bool> AdicionarConfirmacaoUsuario(UsuarioConfirmacao usuarioConfirmacao);
        Task<UsuarioConfirmacao> ObterConfirmacaoUsuario(Guid usuarioId);
        void AtualizarConfirmacaoUsuario(UsuarioConfirmacao usuarioConfirmacao);
        Task<Usuario> ObterUsuarioPorId(Guid id);
        Task<bool> Commit();
        Task<Usuario> ObterUsuarioPorEmail(string email);
        Task<IEnumerable<UsuarioConfirmacao>> ObterCodigosAtivosUsuario(Guid usuarioId);
        Task DesativarCodigosAtivoUsuario(IEnumerable<UsuarioConfirmacao> codigosAtivosUsuario);
        Task AdicionarPerfil(Perfil perfil);
        Task AdicionarPermissoesPerfil(IEnumerable<PerfilPermissao> perfilPermissoes);
        Task AdicionarPerfilUsuario(UsuarioPerfil usuarioPerfil);
        Task<bool> Existe<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<UsuarioPerfil> ObterPerfilUsuario(Guid usuarioId);
    }
}

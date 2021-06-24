using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task AdicionarAsync(Usuario usuario);
        Task<Cliente> ObterCliente(string email);
        void RemoverUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        Task<IEnumerable<Usuario>> ObterTodos();
    }
}

using AcademiaMW.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task AdicionarAsync(Usuario usuario);
        Task<Usuario> ObterUsuario(Guid id);
        void RemoverUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        Task<IEnumerable<Usuario>> ObterTodos();
    }
}

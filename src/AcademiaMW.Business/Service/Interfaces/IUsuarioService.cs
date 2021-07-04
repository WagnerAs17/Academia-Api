using AcademiaMW.Business.Models;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IUsuarioService : IService
    {
        Task<Cliente> AutenticarCliente(string email, string senha);
        Task ConfirmarConta(Guid usuarioId, string codigo);
    }
}

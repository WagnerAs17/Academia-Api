using AcademiaMW.Business.Models;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<Cliente> AutenticarCliente(string email, string senha);
    }
}

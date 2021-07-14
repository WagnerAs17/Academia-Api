using AcademiaMW.Business.Models;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IContaService : IService
    {
        bool SenhaForte(string senha);
        Task<Cliente> AutenticarCliente(string email, string senha);
        Task<Result<Funcionario>> AutenticarFuncionario(string email, string senha);
        Task ConfirmarConta(Guid usuarioId, string codigo);
        Task<bool> ResetarSenha(NovaSenhaUsuario novaSenhaUsuario);
    }
}

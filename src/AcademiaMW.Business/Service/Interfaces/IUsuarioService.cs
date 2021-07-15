using AcademiaMW.Business.Models;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IUsuarioService : IService
    {
        Usuario GerarNovoUsuarioFuncionario();
        Usuario GerarNovoUsuarioCliente(string senha);
        Task<Guid> GerarNovoCodigoConfirmacao(string enderecoEmail);
        Task AdicionarPerfil(Perfil perfil);
        Task AdicionarPermissaoPerfil(PerfilPermissao perfilPermissao);
        Task AdicionarPerfilUsuario(UsuarioPerfil usuarioPerfil);
    }
}

using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcademiaMW.Infra.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AcademiaContext _context;

        public UsuarioRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task<Cliente> ObterCliente(string email)
        {
            return await _context.Clientes.Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Email.Endereco == email);
        }

        public async Task<Funcionario> ObterFuncionario(string email)
        {
            return await _context.Funcionarios
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Email.Endereco == email);
        }

        public async Task<UsuarioConfirmacao> ObterConfirmacaoUsuario(Guid usuarioId)
        {
            return await _context.UsuarioConfirmacao.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.Ativo);
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task<bool> AdicionarConfirmacaoUsuario(UsuarioConfirmacao usuarioConfirmacao)
        {
            await _context.UsuarioConfirmacao.AddAsync(usuarioConfirmacao);

            return await _context.SaveChangesAsync() > 0;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void AtualizarConfirmacaoUsuario(UsuarioConfirmacao usuarioConfirmacao)
        {
            _context.UsuarioConfirmacao.Update(usuarioConfirmacao);
        }

        public void RemoverUsuario(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        
        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            return await _context.Usuarios.Include(x => x.Clientes)
                .Include(x => x.Funcionarios)
                .Include(x => x.UsuarioPerfis)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await _context.Usuarios.Include(x => x.Funcionarios)
                .Include(x => x.Clientes)
                .Where(x => 
                    x.Clientes.Any(x => x.Email.Endereco == email) || 
                    x.Funcionarios.Any(x => x.Email.Endereco == email))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UsuarioConfirmacao>> ObterCodigosAtivosUsuario(Guid usuarioId)
        {
            return await _context.UsuarioConfirmacao.Where(x => x.UsuarioId == usuarioId && x.Ativo)
                .ToListAsync();
        }

        public async Task DesativarCodigosAtivoUsuario(IEnumerable<UsuarioConfirmacao> codigosAtivosUsuario)
        {
            _context.UsuarioConfirmacao.UpdateRange(codigosAtivosUsuario);

            await _context.SaveChangesAsync();
        }

        public async Task AdicionarPerfil(Perfil perfil)
        {
            await _context.Perfis.AddAsync(perfil);

            await _context.SaveChangesAsync();
        }

        public async Task AdicionarPermissoesPerfil(IEnumerable<PerfilPermissao> perfilPermissoes)
        {
            await _context.PerfilPermissoes.AddRangeAsync(perfilPermissoes);

            await _context.SaveChangesAsync();
        }

        public async Task AdicionarPerfilUsuario(UsuarioPerfil usuarioPerfil)
        {
            await _context.UsuarioPerfis.AddAsync(usuarioPerfil);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Existe<T>(Expression<Func<T, bool>> expression) where T :class
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task<UsuarioPerfil> ObterPerfilUsuario(Guid usuarioId)
        {
            return await _context.UsuarioPerfis.Include(x => x.Perfil)
                .ThenInclude(x => x.PerfilPermissoes)
                .FirstOrDefaultAsync(x => x.UsuarioId == usuarioId);
        }
    }
}

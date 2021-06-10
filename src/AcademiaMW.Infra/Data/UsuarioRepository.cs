using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<Usuario> ObterUsuario(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
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
    }
}

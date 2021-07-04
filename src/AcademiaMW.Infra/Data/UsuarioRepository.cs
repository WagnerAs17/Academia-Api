﻿using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Cliente> ObterCliente(string email)
        {
            return await _context.Clientes.Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Email.Endereco == email);
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

using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcademiaMW.Infra.Data
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AcademiaContext _context;

        public FuncionarioRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task<bool> Contratar(Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);

            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> Existe(Expression<Func<Funcionario, bool>> expression)
        {
            return _context.Funcionarios.AnyAsync(expression);
        }

        public async Task<bool> NovoCargo(Cargo cargo)
        {
            await _context.Cargo.AddAsync(cargo);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Cargo>> ObterCargos()
        {
            return await _context.Cargo.ToListAsync();
        }

        public async Task<Cargo> ObterCargoPorId(Guid id)
        {
            return await _context.Cargo.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

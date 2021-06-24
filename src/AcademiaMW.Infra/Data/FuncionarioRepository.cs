using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}

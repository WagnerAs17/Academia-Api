using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcademiaMW.Infra.Data
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly AcademiaContext _context;
        private IQueryable<Plano> _query;

        public PlanoRepository(AcademiaContext context)
        {
            _context = context;
            _query = _context.Planos.AsQueryable();
        }

        public async Task Adicionar(PlanoValor plano)
        {
            await _context.PlanoValor.AddAsync(plano);

            await _context.SaveChangesAsync();
        }

        public async Task AdicionarDesconto(PlanoDesconto desconto)
        {
            await _context.PlanoDescontos.AddAsync(desconto);
        }

        public async Task<IEnumerable<PlanoDesconto>> ObterDescontoAtivos(Guid planoValorId)
        {
            return await _context.PlanoDescontos
                .Where(x => x.PlanoValorId == planoValorId && x.Ativo)
                .ToListAsync();
        }

        public async Task<PlanoDesconto> ObterDescontoPlano(Guid planoId)
        {
            return await _context.PlanoDescontos
                .Include(x => x.PlanoValor)
                .FirstOrDefaultAsync(x => x.PlanoValor.PlanoId == planoId && x.PlanoValor.Ativo && x.Ativo);
        }

        public async Task<Paginated<Plano>> ObterPlanos(Pagination pagination)
        {
            _query = _query.Include(x => x.PlanoValores)
                .ThenInclude(x => x.PlanoDescontos)
                .Where(x => x.Ativo);

            AplicarFiltro(pagination.Search);

            return await PaginatedList<Plano>.CreateAsync(_query, pagination.PageIndex, pagination.PageSize);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlanoValor>> ObterValoresAtivosPlano(Guid planoId)
        {
            return await _context.PlanoValor
                .Where(x => x.PlanoId == planoId && x.Ativo)
                .ToListAsync();
        }

        private void AplicarFiltro(string seach)
        {
            if (!string.IsNullOrEmpty(seach))
                _query = _query.Where(p => p.Nome.ToLower().Contains(seach.ToLower()));
        }

        public async Task<bool> Existe(Expression<Func<Plano, bool>> expression)
        {
            return await _context.Planos.AnyAsync(expression);
        }
    }
}

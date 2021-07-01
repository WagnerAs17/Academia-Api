using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Adicionar(Plano plano)
        {
            await _context.Planos.AddAsync(plano);

            await _context.SaveChangesAsync();
        }

        public async Task AdicionarDesconto(PlanoDesconto desconto)
        {
            await _context.PlanoDescontos.AddAsync(desconto);
        }

        public async Task<IEnumerable<PlanoDesconto>> ObterDescontoAtivos(Guid planoId)
        {
            return await _context.PlanoDescontos
                .Where(x => x.PlanoId == planoId && x.Ativo)
                .ToListAsync();
        }

        public async Task<PlanoDesconto> ObterDescontoPlano(Guid planoId)
        {
            return await _context.PlanoDescontos
                .FirstOrDefaultAsync(x => x.PlanoId == planoId);
        }

        public async Task<Paginated<Plano>> ObterPlanos(Pagination pagination)
        {
            AplicarFiltro(pagination.Search);

            return await PaginatedList<Plano>.CreateAsync(_query, pagination.PageIndex, pagination.PageSize);
        }

        private void AplicarFiltro(string seach)
        {
            if (!string.IsNullOrEmpty(seach))
                _query = _query.Where(p => p.Nome.ToLower().Contains(seach.ToLower()));
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}

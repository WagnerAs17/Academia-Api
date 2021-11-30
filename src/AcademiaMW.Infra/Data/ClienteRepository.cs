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
    public class ClienteRepository : IClienteRepository
    {
        private readonly AcademiaContext _context;
        private IQueryable<Cliente> _query;
        public ClienteRepository(AcademiaContext context)
        {
            _context = context;
            _query = _context.Clientes.AsQueryable();
        }

        public async Task<Cliente> ObterClientePorId(Guid id)
        {
            return await Query()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        private IQueryable<Cliente> Query()
        {
            return _context.Clientes
                     .AsNoTracking()
                     .Include(x => x.Contrato)
                     .ThenInclude(x => x.PlanoDesconto)
                     .ThenInclude(x => x.PlanoValor)
                     .ThenInclude(x => x.Plano).AsQueryable();
        }

        public async Task<Paginated<Cliente>> ObterTodos(Pagination pagination)
        {
            _query = Query();

            AplicarFiltro(pagination.Search);

            return await PaginatedList<Cliente>.CreateAsync(_query, pagination.PageIndex, pagination.PageSize);
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Existe(Expression<Func<Cliente, bool>> expression)
        {
            return await _context.Clientes.AnyAsync(expression);
        }

        private void AplicarFiltro(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();

                _query = _query.Where(x => x.Nome.ToLower().Contains(search)
                    || x.Email.Endereco.ToLower().Contains(search)
                    || x.CPF.Numero.ToLower().Contains(search)
                    || x.Contrato.PlanoDesconto.PlanoValor.Plano.Nome.ToLower().Contains(search));
            }
        }

        public async Task<bool> AdicionarTreinoItens(List<TreinoItem> treinoItens)
        {
            await _context.TreinoItens.AddRangeAsync(treinoItens);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}

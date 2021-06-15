using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
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
            _query = _context.Clientes
                 .AsNoTracking()
                 .Include(x => x.Contrato)
                 .ThenInclude(x => x.Plano).AsQueryable();
        }
       
        public async Task<Cliente> ObterClientePorId(Guid id)
        {
            return await _query
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Paginated<Cliente>> ObterTodos(Pagination pagination)
        {
            AplicarFiltro(pagination.Search);

            return await PaginatedList<Cliente>.CreateAsync(_query, pagination.PageIndex, pagination.PageSize);
        }

        public async Task Adicionar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);

            await _context.SaveChangesAsync();
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
                    || x.Contrato.Plano.Nome.ToLower().Contains(search)
                    || x.Contrato.Plano.Valor.ToString().Contains(search));
            }
        }
    }
}

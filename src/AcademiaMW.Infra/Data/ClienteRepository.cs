using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMW.Infra.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AcademiaContext _context;

        public ClienteRepository(AcademiaContext context)
        {
            _context = context;
        }
        public async Task Adicionar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);

            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> ObterClientePorId(Guid id)
        {
            return await _context.Clientes.AsNoTracking()
                .Include(x => x.Contrato)
                .ThenInclude(x => x.Plano)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

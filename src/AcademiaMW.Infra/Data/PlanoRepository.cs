using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMW.Infra.Data
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly AcademiaContext _context;

        public PlanoRepository(AcademiaContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Plano plano)
        {
            await _context.Planos.AddAsync(plano);

            await _context.SaveChangesAsync();
        }
    }
}

using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IAulaRepository : IRepository<Aula>
    {
        Task Adicionar(Aula aula);
        Task<Aula> ObterAulaPorId(Guid aulaId);
        Task AdicionarProgramacao(Programacao programacao);
    }
}

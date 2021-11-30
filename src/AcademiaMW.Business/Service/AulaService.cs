using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class AulaService : Service
    {
        private readonly IAulaRepository _aulaRepository;

        public AulaService
        (
            IAulaRepository aulaRepository,
            INotificador notificador
        ) : base(notificador)
        {
            _aulaRepository = aulaRepository;
        }

        public async Task Adicionar(Aula aula)
        {
            if (!aula.EhValido())
            {
                Notificar(aula.ValidationResult);
            }

            await _aulaRepository.Adicionar(aula);
        }

        public async Task<Aula> ObterAulaId(Guid id){
            return await _aulaRepository.ObterAulaPorId(id);
        }

        public async Task AdicionarProgramacao(Programacao programacao)
        {
             await _aulaRepository.AdicionarProgramacao(programacao);
        }
    }
}

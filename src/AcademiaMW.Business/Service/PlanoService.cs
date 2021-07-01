using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Core.Domain;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class PlanoService : Service, IPlanoService
    {
        private readonly IPlanoRepository _planoRepository;

        public PlanoService
        (
            INotificador notificador, 
            IPlanoRepository planoRepository
        ) : base(notificador)
        {
            _planoRepository = planoRepository;
        }

        public async Task<bool> Adicionar(Plano plano)
        {
            if (!plano.EhValido())
            {
                Notificar(plano.ValidationResult);
                return false;
            }

            await _planoRepository.Adicionar(plano);

            return true;
        }

        public async Task<Paginated<Plano>> ObterPlanosPaginados(Pagination pagination)
        {
            return await _planoRepository.ObterPlanos(pagination);
        }

        public async Task AdicionarDescontoPlano(PlanoDesconto planoDesconto)
        {
            var descontosAtivos = await _planoRepository
                .ObterDescontoAtivos(planoDesconto.PlanoId);
            
            foreach (var desconto in descontosAtivos)
            {
                desconto.Ativo = false;
            }

            await _planoRepository.AdicionarDesconto(planoDesconto);

            await _planoRepository.Commit();
        }
    }
}

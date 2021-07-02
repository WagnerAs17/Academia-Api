using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> Adicionar(PlanoValor planoValor)
        {
            if (!planoValor.EhValido())
            {
                Notificar(planoValor.ValidationResult);
                Notificar(planoValor.Plano.ValidationResult);
                return false;
            }

            var planoValores = await _planoRepository.ObterValoresAtivosPlano(planoValor.Plano.Id);

            foreach (var valor in planoValores)
            {
                valor.DesativarValor();
            }

            await _planoRepository.Adicionar(planoValor);

            return true;
        }

        public async Task<Paginated<Plano>> ObterPlanosPaginados(Pagination pagination)
        {
            return await _planoRepository.ObterPlanos(pagination);
        }

        public async Task AdicionarDescontoPlano(Guid planoId, PlanoDesconto planoDesconto)
        {
            if (!planoDesconto.EhValido())
            {
                Notificar("A Quantidade de meses tem que ser maior que 0");
                return;
            }

            var planoValores = await _planoRepository.ObterValoresAtivosPlano(planoId);

            if (!ValidarValoresPlano(planoValores))
                return;

            var valorPlano = planoValores.FirstOrDefault();

            var descontosAtivos = await _planoRepository
                .ObterDescontoAtivos(valorPlano.Id);

            foreach (var desconto in descontosAtivos)
            {
                desconto.DesativarDesconto();
            }

            planoDesconto.AdicionarValor(valorPlano);

            await _planoRepository.AdicionarDesconto(planoDesconto);

            await _planoRepository.Commit();
        }

        private bool ValidarValoresPlano(IEnumerable<PlanoValor> planoValores)
        {
            if (!planoValores.Any())
            {
                Notificar("Plano não tem nenhum valor associado");
                return false;
            }

            if (planoValores.Count() > 1)
            {
                Notificar("Esse plano tem mais de um valor associado");
                return false;
            }

            return true;
        }

    }
}

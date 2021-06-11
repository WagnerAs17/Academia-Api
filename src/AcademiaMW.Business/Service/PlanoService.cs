using AcademiaMW.Business.Models;
using AcademiaMW.Business.Notifications;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service
{
    public class PlanoService : Service, IPlanoService
    {
        public PlanoService(INotificador notificador) : base(notificador)
        {

        }

        public Task<bool> Adicionar(Plano plano)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPlanoService
    {
        Task<bool> Adicionar(Plano plano);
    }
}

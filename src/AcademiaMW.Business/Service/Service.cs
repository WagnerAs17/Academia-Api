using AcademiaMW.Business.Notifications;
using AcademiaMW.Core.Domain;
using FluentValidation;
using FluentValidation.Results;

namespace AcademiaMW.Business.Service
{
    public abstract class Service
    {
        private readonly INotificador _notificador;
        public Service(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}

using System.Collections.Generic;

namespace AcademiaMW.Business.Notifications
{
    public interface INotificador
    {
        void Handle(Notificacao notificacao);
        List<Notificacao> ObterErros();
        bool TemNotificacao();
    }
}

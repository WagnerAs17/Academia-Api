using System.Collections.Generic;

namespace AcademiaMW.Business.Notifications
{
    public interface INotification
    {
        void AdicionarErro(string mensagem);
        List<string> ObterErros();
    }
}

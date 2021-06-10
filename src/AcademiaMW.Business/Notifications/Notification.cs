using System.Collections.Generic;

namespace AcademiaMW.Business.Notifications
{
    public class Notification : INotification
    {
        private List<string> _erros;
        public Notification()
        {
            _erros = new List<string>();
        }

        public void AdicionarErro(string mensagem)
        {
            _erros.Add(mensagem);
        }

        public List<string> ObterErros()
        {
            return _erros;
        }
    }
}

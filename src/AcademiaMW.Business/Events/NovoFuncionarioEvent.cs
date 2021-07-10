using AcademiaMW.Core.Messages;

namespace AcademiaMW.Business.Events
{
    public class NovoFuncionarioEvent : Event
    {
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public NovoFuncionarioEvent(string email, string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Email = email;
            Senha = senha;
        }
    }
}

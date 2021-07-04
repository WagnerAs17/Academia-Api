using AcademiaMW.Core.Domain;
using System;

namespace AcademiaMW.Business.Models
{
    public class UsuarioConfirmacao : Entity
    {
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Codigo { get; private set; }
        public DateTime DateInicial { get; private set; }
        public DateTime DateExpiracao { get; private set; }
        public bool Ativo { get; private set; }

        public UsuarioConfirmacao(Guid usuarioId)
        {
            UsuarioId = usuarioId;
            GerarCodigo();
            DateInicial = DateTime.Now;
            DateExpiracao = DateInicial.AddMinutes(5);
            Ativo = true;
        }
        
        private void GerarCodigo()
        {
            var random = new Random();

            for (int i = 0; i < 6; i++)
            {
                Codigo += random.Next(0, 9);
            }
        }

        public bool CodigoValido()
        {
            return DateTime.Now > DateExpiracao;
        }

        public void DesativarCodigoConfirmacao()
        {
            Ativo = false;
        }

    }
}

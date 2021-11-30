using AcademiaMW.Core.Domain;
using System;

namespace AcademiaMW.Business.Models
{
    public class TreinoItem : Entity
    {
        public Treino Treino { get; private set; }
        public Guid TreinoId { get; set; }
        public string Nome { get; private set; }
        public int Repeticao { get; private set; }

        public TreinoItem(Treino treino, string nome, int repeticao)
        {
            Treino = treino;
            TreinoId = treino.Id;
            Nome = nome;
            Repeticao = repeticao;
        }

        protected TreinoItem() { }

        public override bool EhValido()
        {
            return !string.IsNullOrEmpty(Nome) && Repeticao > 0;
        }
    }
}

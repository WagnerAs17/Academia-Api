using AcademiaMW.Core.Domain;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class Treino : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Cliente Cliente { get; private set; }
        public Guid ClienteId { get; set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public IEnumerable<TreinoItem> TreinoItens { get; set; }

        public Treino(Guid clienteId, string nome, string descricao)
        {
            ClienteId = clienteId;
            Nome = nome;
            Descricao = descricao;
            Ativo = true;
            DataCriacao = DateTime.Now;
        }

        protected Treino()
        {
        }

        public override bool EhValido()
        {
            return !string.IsNullOrEmpty(Nome);
        }
    }
}

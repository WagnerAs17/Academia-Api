using AcademiaMW.Core.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class Plano : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }

        //EF
        public ICollection<PlanoValor> PlanoValores { get; set; }
        protected Plano() { }

        public Plano(string nome)
        {
            Nome = nome;
            DataCriacao = DateTime.Now;
        }
    }
}

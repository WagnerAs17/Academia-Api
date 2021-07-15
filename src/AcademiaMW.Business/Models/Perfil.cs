﻿using AcademiaMW.Core.Domain;
using System.Collections.Generic;

namespace AcademiaMW.Business.Models
{
    public class Perfil : Entity
    {
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        public Perfil(string nome)
        {
            Nome = nome;
        }

        //EF
        protected Perfil() { }
        public ICollection<UsuarioPerfil> UsuarioPerfis { get; set; }
    }
}

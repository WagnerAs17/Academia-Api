using System;
using AcademiaMW.Core.Domain;

namespace AcademiaMW.Business.Models
{
    public class PlanoAula : Entity
    {
        public Guid AulaId { get; set; }
        public Aula Aula { get; set; }
        public Guid PlanoId { get; set; }
        public Plano Plano { get; set; }
        protected PlanoAula()
        {
        }
    }
}
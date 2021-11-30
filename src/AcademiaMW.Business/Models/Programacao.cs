using System;
using AcademiaMW.Core.Domain;

namespace AcademiaMW.Business.Models
{
    public class Programacao : Entity
    {
        public Guid AulaId { get; set; }
        public Aula Aula { get; set; }
        public bool Ativo { get; set; }
        public string Horarios { get; set; }
        public int TempoAula { get; set; }
        protected Programacao()
        {

        }

        public Programacao(Guid aulaId, string horarios, int tempoAula)
        {
            AulaId = aulaId;
            Horarios = horarios;
            TempoAula = tempoAula;
            Ativo = true;
        }

        public string[] ObterHorarios()
        {
            string[] horas = new string[]{};

            if(Horarios.Contains(";"))
            {
                horas = Horarios.Split(";");
            }

            return horas;
        }

        //Horario do plano não pode ser maior que o horario de fechamento
        //e não pode ser menor que o horário de abertura
        //Posso criar uma tabela ou definir uma file .json;
        //O que é melhor ?
        //academia.json
    }
}
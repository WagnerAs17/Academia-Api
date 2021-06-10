using AcademiaMW.Core.ValueTypes;
using AcademiaMW.Business.Validations;
using FluentValidation.Results;
using System;
using AcademiaMW.Core.Domain;

namespace AcademiaMW.Business.Models
{
    public class Cliente : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public CPF CPF { get; private set; }
        public Email Email { get; set; }
        public DateTime DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        //EF
        public Usuario Usuario { get; set; }
        public Guid UserId { get; set; }
        public PlanoValor PlanoValor { get; set; }
        public Guid PlanoValorId { get; set; }

        protected Cliente() { }

        public Cliente
        (
            Guid userId,
            Guid planoValorId,
            string nome, 
            DateTime dataNascimento, 
            string cpf, 
            string email,
            Endereco endereco
        )
        {
            UserId = userId;
            PlanoValorId = planoValorId;
            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = new CPF(cpf);
            Email = new Email(email);
            Endereco = endereco;
        }

        public bool EhMaiorDeTrezeAnos()
        {
            return (DateTime.Now.Year - DataNascimento.Year) > 13;
        }

        public override bool EhValido()
        {
            ValidationResult = new ClienteValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }

    
}

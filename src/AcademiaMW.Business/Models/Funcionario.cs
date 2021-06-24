using AcademiaMW.Business.Validations;
using AcademiaMW.Core.Domain;
using AcademiaMW.Core.ValueTypes;
using System;

namespace AcademiaMW.Business.Models
{
    public class Funcionario : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public CPF CPF { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }

        public Funcionario(string nome, Email email, CPF cpf, Guid cargoId, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            CargoId = cargoId;
            DataNascimento = dataNascimento;
            Ativo = false;
        }

        public bool EhMaiorDeIdade()
        {
            return (DateTime.Now.Year - DataNascimento.Year) >= 18;
        }

        public override bool EhValido()
        {
            ValidationResult = new FuncionarioValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        //EF
        protected Funcionario() { }
        public Cargo Cargo { get; set; }
        public Guid CargoId { get; set; }
    }
}

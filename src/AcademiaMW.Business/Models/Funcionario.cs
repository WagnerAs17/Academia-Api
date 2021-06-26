using AcademiaMW.Business.Validations;
using AcademiaMW.Core.Domain;
using AcademiaMW.Core.ValueTypes;
using System;

namespace AcademiaMW.Business.Models
{
    public class Funcionario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public CPF CPF { get; private set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }

        public Funcionario
        (
            string nome, string email, string cpf, 
            string senha, Guid cargoId, DateTime dataNascimento
        )
        {
            Nome = nome;
            Email = new Email(email);
            CPF = new CPF(cpf);
            CargoId = cargoId;
            DataNascimento = dataNascimento;
            Usuario = new Usuario(senha);
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

        public static class FuncionarioFactory
        {
            public static Funcionario CriarFuncionario(
                string nome, string email, string cpf, 
                string senha, Guid cargoId, DateTime dataNascimento
            )
            {
                return new Funcionario(
                    nome, email, cpf,
                    senha, cargoId, dataNascimento
                );
            }
        }
    }
}

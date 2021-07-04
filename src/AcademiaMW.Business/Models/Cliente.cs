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
        public string Imagem { get; set; }
        public CPF CPF { get; private set; }
        public Core.ValueTypes.Email Email { get; set; }
        public DateTime DataNascimento { get; private set; }
        public Endereco Endereco { get; private set; }
        
        //EF
        public Usuario Usuario { get; set; }
        public Guid UserId { get; set; }
        public Contrato Contrato { get; set; }
        public Guid ContratoId { get; set; }
        protected Cliente() { }

        public Cliente
        (
            Usuario usuario,
            string nome, 
            DateTime dataNascimento, 
            string cpf, 
            string email
        )
        {
            Usuario = usuario;
            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = new CPF(cpf);
            Email = new Core.ValueTypes.Email(email);
        }

        public bool EhMenorDeTrezeAnos()
        {
            return (DateTime.Now.Year - DataNascimento.Year) <= 13;
        }

        public override bool EhValido()
        {
            ValidationResult = new ClienteValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        public void AdicionarContrato(Contrato contrato)
        {
            Contrato = contrato;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public static class ClienteFactory
        {
            public static Cliente CriarClienteComContrato(
                string senha, string nome, DateTime dataNascimento, 
                string cpf, string email)
            {
                return new Cliente(
                    new Usuario(senha), 
                    nome, dataNascimento, cpf, email);
            }
        }
    }

    
}

using AcademiaMW.Core.ValueTypes;
using AcademiaMW.Business.Validations;
using FluentValidation.Results;
using System;
using AcademiaMW.Core.Domain;
using AcademiaMW.Business.Enum;

namespace AcademiaMW.Business.Models
{
    public class Cliente : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Imagem { get; set; }
        public CPF CPF { get; private set; }
        public Email Email { get; set; }
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
            Contrato contrato,
            string nome, 
            DateTime dataNascimento, 
            string cpf, 
            string email
        )
        {
            Usuario = usuario;
            Contrato = contrato;
            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = new CPF(cpf);
            Email = new Email(email);
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

        public void AdicionarEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public static class ClienteFactory
        {
            public static Cliente CriarClienteComContrato(
                string senha, Guid planoId, TempoContrato tempoContrato, 
                decimal percentual,string nome, DateTime dataNascimento, 
                string cpf, string email)
            {
                return new Cliente(new Usuario(senha), 
                    new Contrato(planoId, tempoContrato, percentual), 
                    nome, dataNascimento, cpf, email)
                {

                };
            }
        }
    }

    
}

using AcademiaMW.Core.ValueTypes;
using AcademiaMW.Business.Models;
using FluentValidation;

namespace AcademiaMW.Business.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório");

            RuleFor(x => x.CPF.Numero)
                .Must(CPF.Validar)
                .WithMessage("CPF informado inválido.");

            RuleFor(x => x.CPF.Numero.Length)
                .Equal(CPF.Max_Length)
                .WithMessage("CPF deve ter 11 caracteres");

            RuleFor(x => x.Endereco.Logradouro)
                .NotEmpty()
                .WithMessage("Informe o logradouro.");

            RuleFor(x => x.Endereco.Logradouro.Length)
                .LessThanOrEqualTo(350)
                .WithMessage("O logradouro deve ter até 350 caracteres");

            RuleFor(x => x.Endereco.Bairro)
                .NotEmpty()
                .WithMessage("Informe o bairro.");

            RuleFor(x => x.Endereco.Bairro.Length)
                .LessThanOrEqualTo(250)
                .WithMessage("O bairro deve ter até 250 caracteres");

            RuleFor(x => x.Endereco.Cep)
                .NotEmpty()
                .WithMessage("Informe o CEP.");

            RuleFor(x => x.Endereco.Cep.Length)
               .Equal(8)
               .WithMessage("O CEP deve ter 8 caracteres");

            RuleFor(x => x.Endereco.Cidade)
                .NotEmpty()
                .WithMessage("Informe a cidade.");

            RuleFor(x => x.Endereco.Cidade.Length)
                .LessThanOrEqualTo(350)
                .WithMessage("O logradouro deve ter até 350 caracteres.");

            RuleFor(x => x.Endereco.Estado)
                .NotEmpty()
                .WithMessage("Informe o estado.");

            RuleFor(x => x.Endereco.Estado.Length)
                .Equal(2)
                .WithMessage("O Estado deve ter 2 caracteres");
        }
    }
}

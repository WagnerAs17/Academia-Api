using AcademiaMW.Business.Models;
using FluentValidation;

namespace AcademiaMW.Business.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(x => x.Logradouro)
                .NotEmpty()
                .WithMessage("Informe o logradouro.");

            RuleFor(x => x.Logradouro.Length)
                .LessThanOrEqualTo(350)
                .WithMessage("O logradouro deve ter até 350 caracteres");

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .WithMessage("Informe o bairro.");

            RuleFor(x => x.Bairro.Length)
                .LessThanOrEqualTo(250)
                .WithMessage("O bairro deve ter até 250 caracteres");

            RuleFor(x => x.Cep)
                .NotEmpty()
                .WithMessage("Informe o CEP.");

            RuleFor(x => x.Cep.Length)
               .Equal(8)
               .WithMessage("O CEP deve ter 8 caracteres");

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .WithMessage("Informe a cidade.");

            RuleFor(x => x.Cidade.Length)
                .LessThanOrEqualTo(350)
                .WithMessage("O logradouro deve ter até 350 caracteres.");

            RuleFor(x => x.Estado)
                .NotEmpty()
                .WithMessage("Informe o estado.");

            RuleFor(x => x.Estado.Length)
                .NotEqual(2)
                .WithMessage("O Estado deve ter 2 caracteres");
        }
    }
}

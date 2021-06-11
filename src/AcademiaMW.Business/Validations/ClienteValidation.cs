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

            RuleFor(x => x.EhMenorDeTrezeAnos())
                .Equal(true)
                .WithMessage("O Cliente deve ter mais de 13 anos");

            RuleFor(x => x.CPF.Numero)
                .Must(CPF.Validar)
                .WithMessage("CPF informado inválido.");

            RuleFor(x => x.CPF.Numero.Length)
                .Equal(CPF.Max_Length)
                .WithMessage("CPF deve ter 11 caracteres");
        }
    }
}

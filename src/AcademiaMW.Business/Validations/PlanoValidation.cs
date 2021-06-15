using AcademiaMW.Business.Models;
using FluentValidation;

namespace AcademiaMW.Business.Validations
{
    public class PlanoValidation : AbstractValidator<Plano>
    {
        public PlanoValidation()
        {
            RuleFor(x => x.Valor)
                .NotEmpty()
                .WithMessage("O valor do plano não pode ser zero.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome do plano é obrigatório.");
        }
    }
}

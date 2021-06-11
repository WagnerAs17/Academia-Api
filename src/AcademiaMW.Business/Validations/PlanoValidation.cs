using AcademiaMW.Business.Models;
using FluentValidation;

namespace AcademiaMW.Business.Validations
{
    public class PlanoValidation : AbstractValidator<Plano>
    {
        public PlanoValidation()
        {
            RuleFor(x => x.Valor)
                .Equal(decimal.Zero)
                .WithMessage("O valor do plano não pode ser zero.");

            RuleFor(x => x.Nome)
                .Empty()
                .WithMessage("O nome do plano é obrigatório.");
        }
    }
}

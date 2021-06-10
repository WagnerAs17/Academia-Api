using AcademiaMW.Business.Models;
using FluentValidation;

namespace AcademiaMW.Business.Validations
{
    public class PlanoValorValidation : AbstractValidator<PlanoValor>
    {
        public PlanoValorValidation()
        {
            RuleFor(x => x.Valor)
                .GreaterThanOrEqualTo(decimal.Zero)
                .WithMessage("O valor deve ser maior que zero");
        }
    }
}

using AcademiaMW.Business.Models;
using FluentValidation;

namespace AcademiaMW.Business.Validations
{
    public class AulaValidation : AbstractValidator<Aula>
    {
        public AulaValidation()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("O campo descrição é obrigatório");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo nome é obrigatório");

            RuleFor(x => x.Descricao.Length)
                .LessThanOrEqualTo(1000)
                .WithMessage("O campo descrição deve ter até 1000 caracteres");

            RuleFor(x => x.Nome.Length)
                .LessThanOrEqualTo(200)
                .WithMessage("O campo nome deve ter até 200 caracteres");

        }
    }
}

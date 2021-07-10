using AcademiaMW.Business.Models;
using FluentValidation;

namespace AcademiaMW.Business.Validations
{
    public class FuncionarioValidation : AbstractValidator<Funcionario>
    {
        public FuncionarioValidation()
        {
            RuleFor(f => f.EhMaiorDeIdade())
                .NotEqual(false)
                .WithMessage("O funcionario não pode ser menor de idade");

            RuleFor(f => f.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório");
        }
    }
}

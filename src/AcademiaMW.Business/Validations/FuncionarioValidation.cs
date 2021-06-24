using AcademiaMW.Business.Models;
using FluentValidation;

namespace AcademiaMW.Business.Validations
{
    public class FuncionarioValidation : AbstractValidator<Funcionario>
    {
        public FuncionarioValidation()
        {
            RuleFor(f => f.EhMaiorDeIdade())
                .Equal(false)
                .WithMessage("O funcionario não pode ser menor de idade");

            RuleFor(f => f.Nome)
                .Empty()
                .WithMessage("O nome é obrigatório");
        }
    }
}

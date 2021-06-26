using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using System;

namespace AcademiaMW.Mapper
{
    public class FuncionarioMapper
    {
        public static Funcionario FuncionarioDtoParaFuncionario(FuncionarioDto funcionario)
        {
            return Funcionario.FuncionarioFactory.CriarFuncionario
                (funcionario.Nome, funcionario.Email,
                funcionario.Cpf, funcionario.Senha, Guid.Parse(funcionario.CargoId), funcionario.DataNascimento);

        }
    }
}

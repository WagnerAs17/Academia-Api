using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using System;

namespace AcademiaMW.Mapper
{
    public class FuncionarioMapper
    {
        public static Funcionario FuncionarioDtoParaFuncionario(FuncionarioDto funcionario, Usuario usuario)
        {
            return Funcionario.FuncionarioFactory.CriarFuncionario
                (funcionario.Nome, funcionario.Email,
                funcionario.Cpf, usuario, Guid.Parse(funcionario.CargoId), funcionario.DataNascimento);

        }
    }
}

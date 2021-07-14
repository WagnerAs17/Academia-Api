using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using System;
using System.Collections.Generic;

namespace AcademiaMW.Mapper
{
    public static class FuncionarioMapper
    {
        public static Funcionario FuncionarioDtoParaFuncionario(this FuncionarioDto funcionario, Usuario usuario)
        {
            return Funcionario.FuncionarioFactory.CriarFuncionario
                (funcionario.Nome, funcionario.Email,
                funcionario.Cpf, usuario, Guid.Parse(funcionario.CargoId), funcionario.DataNascimento);

        }

        public static IEnumerable<CargoRegistradoDto> CargosParaCargosDto(this IEnumerable<Cargo> cargos)
        {
            var cargosDto = new List<CargoRegistradoDto>();

            foreach (var cargo in cargos)
            {
                cargosDto.Add(new CargoRegistradoDto(cargo.Id, cargo.Nome));
            }

            return cargosDto;
        }
    }
}

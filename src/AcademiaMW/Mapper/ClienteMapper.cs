using AcademiaMW.Business.Enum;
using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using System;

namespace AcademiaMW.Mapper
{
    public static class ClienteMapper
    {
        public static Cliente ClienteDtoParaCliente(ClienteDto clienteDto)
        {
            return Cliente.ClienteFactory
                .CriarClienteComContrato(
                    clienteDto.Senha, Guid.Parse(clienteDto.PlanoId), 
                    (TempoContrato)clienteDto.TempoContrato, clienteDto.Percentual, 
                    clienteDto.Nome, clienteDto.DataNascimento,
                    clienteDto.Cpf, clienteDto.Email);
        }
    }
}

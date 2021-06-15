using AcademiaMW.Business.Enum;
using AcademiaMW.Business.Models;
using AcademiaMW.Dtos;
using System;
using System.Collections.Generic;

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

        public static ClienteRegistradoDto ClienteParaClienteRegistradoDto(Cliente cliente)
        {
            return new ClienteRegistradoDto
            {
                Nome = cliente.Nome,
                Email = cliente.Email.Endereco,
                Plano = cliente.Contrato.Plano.Nome,
                Valor = cliente.Contrato.CalcularValorPlano(),
                VencimentoContrato = cliente.Contrato.DataVencimento
            };
        }

        public static Paginated<ClienteRegistradoDto> PaginatedClientesParaClientesDto(Paginated<Cliente> pagination)
        {
            var paginatedDto = new Paginated<ClienteRegistradoDto>
            {
                PageIndex = pagination.PageIndex,
                TotalPages = pagination.TotalPages,
                HasNextPage = pagination.HasNextPage,
                HasPreviousPage = pagination.HasPreviousPage,
                Data = ClientesParaClientesRegistradosDto(pagination.Data)
            };

            return paginatedDto;
        }

        private static IEnumerable<ClienteRegistradoDto> ClientesParaClientesRegistradosDto(IEnumerable<Cliente> clientes)
        {
            var clientesDto = new List<ClienteRegistradoDto>();

            foreach (var cliente in clientes)
            {
                clientesDto.Add(ClienteParaClienteRegistradoDto(cliente));
            }

            return clientesDto;
        }
    }
}

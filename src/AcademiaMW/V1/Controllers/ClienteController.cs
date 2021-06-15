using AcademiaMW.Business.Models;
using AcademiaMW.Business.Models.Repository;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service;
using AcademiaMW.Controllers;
using AcademiaMW.Core.Domain;
using AcademiaMW.Dtos;
using AcademiaMW.Mapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/clientes")]
    public class ClienteController : MainController
    {
        private readonly IClienteService _clienteService;
        private IClienteRepository _clienteRepository;

        public ClienteController
        (
            INotificador notificador,
            IClienteService clienteService,
            IClienteRepository clienteRepository
        ) : base(notificador)
        {
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Matricular([FromBody] ClienteDto novoCliente)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var cliente = ClienteMapper.ClienteDtoParaCliente(novoCliente);

            await _clienteService.Matricular(cliente);

            return CustomResponse();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterClientePorId(Guid id)
        {
            var cliente = await _clienteService.ObterCliente(id);

            if (cliente is null)
                return NotFound();

            return CustomResponse(ClienteMapper.ClienteParaClienteRegistradoDto(cliente));
        }

        [HttpGet]
        public async Task<Paginated<ClienteRegistradoDto>> ObterTodos([FromQuery] Pagination pagination)
        {
            return ClienteMapper.PaginatedClientesParaClientesDto(
                await _clienteRepository.ObterTodos(pagination));
        }
    }
}

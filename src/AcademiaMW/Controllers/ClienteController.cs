using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service;
using AcademiaMW.Dtos;
using AcademiaMW.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AcademiaMW.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : MainController
    {
        private readonly IClienteService _clienteService;

        public ClienteController
        (
            INotificador notificador,
            IClienteService clienteService
        ) : base(notificador)
        {
            _clienteService = clienteService;
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
    }
}

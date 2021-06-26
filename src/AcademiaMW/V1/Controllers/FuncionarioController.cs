using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Controllers;
using AcademiaMW.Dtos;
using AcademiaMW.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AcademiaMW.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/funcionarios")]
    public class FuncionarioController : MainController
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController
        (
            INotificador notificador,
            IFuncionarioService funcionarioService
        ) : base(notificador)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Contratar([FromBody] FuncionarioDto funcionarioDto)
        {
            var funcionario = FuncionarioMapper.FuncionarioDtoParaFuncionario(funcionarioDto);

            await _funcionarioService.Contratar(funcionario);

            return CustomResponse();
        }
    }
}

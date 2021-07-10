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
        private readonly IUsuarioService _usuarioService;

        public FuncionarioController
        (
            INotificador notificador,
            IFuncionarioService funcionarioService,
            IUsuarioService usuarioService
        ) : base(notificador)
        {
            _funcionarioService = funcionarioService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Contratar([FromBody] FuncionarioDto funcionarioDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var usuario = _usuarioService.GerarNovoUsuarioFuncionario();

            var funcionario = FuncionarioMapper.FuncionarioDtoParaFuncionario(funcionarioDto, usuario);

            await _funcionarioService.Contratar(funcionario);

            return CustomResponse();
        }
    }
}

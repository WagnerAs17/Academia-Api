using AcademiaMW.Business.Models;
using AcademiaMW.Business.Notifications;
using AcademiaMW.Business.Service.Interfaces;
using AcademiaMW.Controllers;
using AcademiaMW.Core.Domain;
using AcademiaMW.Dtos;
using AcademiaMW.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AcademiaMW.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/planos")]
    public class PlanoController : MainController
    {
        private readonly IPlanoService _planoService;

        public PlanoController(IPlanoService planoService, INotificador notificador) : base(notificador)
        {
            _planoService = planoService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Adicionar([FromBody] PlanoDto plano)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _planoService.Adicionar(new PlanoValor(plano.Valor, new Plano(plano.Nome)));

            return CustomResponse();
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPlanos([FromQuery] Pagination pagination)
        {
            var paginatedPlanos = await _planoService.ObterPlanosPaginados(pagination);

            return Ok(PlanoMapper.PaginatedPlanosParaPlanoDto(paginatedPlanos));
        }

        [HttpPost("{planoId:guid}/descontos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AdicionarDesconto([FromRoute] Guid planoId, [FromBody] PlanoDescontoDto desconto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (planoId != desconto.PlanoId)
                return Conflict("Plano informado inválido");

            await _planoService.AdicionarDescontoPlano(desconto.PlanoId,
                PlanoMapper.PlanoDescontoDtoParaPlanoDesconto(desconto));

            return CustomResponse();
        }
    }
}

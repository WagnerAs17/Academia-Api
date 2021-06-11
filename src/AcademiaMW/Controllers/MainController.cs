using AcademiaMW.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace AcademiaMW.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        private readonly INotificador _notificador;

        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected IActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    Success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                Success = false,
                Erros = ObterMensagensErro()
            });
        }

        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);

            return CustomResponse();
        }

        private IEnumerable<string> ObterMensagensErro()
        {
            return _notificador.ObterErros().Select(e => e.Mensagem);
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(er => er.Errors);

            foreach (var erro in erros)
            {
                var msgErro = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;

                NotificarErro(msgErro);
            }
        }
        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace Http.Models
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult CustomResponse(object? result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                soccess = false,
                errors = ObterErros()
            });
        }

        protected bool OperacaoValida()
        {
            return true;
        }

        protected string ObterErros()
        {
            return "";
        }
    }
}

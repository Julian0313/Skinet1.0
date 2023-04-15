using API.Errores;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("error/{codigo}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseController
    {
        public IActionResult Error(int codigo)
        {
            return new ObjectResult(new RespuestaApi(codigo));
        }   
    }
}
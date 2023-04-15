using API.Errores;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseController
    {
        private readonly TiendaContexto _contexto;
        public BuggyController(TiendaContexto contexto)
        {
            _contexto = contexto;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {         
            var cosa = _contexto.Productos.Find(42);   
            if(cosa == null)
            {
                return NotFound(new RespuestaApi(404));
            }            
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var cosa = _contexto.Productos.Find(42); 
            var cosaRetornar = cosa.ToString();

            return Ok();  

        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundrerquest(int id)
        {
            return Ok();
        }
    }
}
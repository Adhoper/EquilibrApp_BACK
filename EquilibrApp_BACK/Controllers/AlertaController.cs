using EquilibrApp_BACK.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquilibrApp_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : Controller
    {
        private readonly IAlertaService _Service;
        public AlertaController(IAlertaService Service)
        {
            this._Service = Service;
        }

        [HttpGet("listar-alertas")]
        public async Task<IActionResult> Listar([FromQuery] int idUsuario, [FromQuery] string periodo, [FromQuery] string estado = null)
        {
            var res = await _Service.Listar(idUsuario, periodo, estado);
            return Ok(res);
        }

        [HttpPut("marcar-leida/{idAlerta:int}")]
        public async Task<IActionResult> MarcarLeida([FromRoute] int idAlerta, [FromQuery] int idUsuario)
        {
            var res = await _Service.MarcarLeida(idUsuario, idAlerta);
            return Ok(res);
        }

        [HttpPut("marcar-todas")]
        public async Task<IActionResult> MarcarTodas([FromQuery] int idUsuario, [FromQuery] string periodo)
        {
            var res = await _Service.MarcarTodas(idUsuario, periodo);
            return Ok(res);
        }

        [HttpPut("descartar/{idAlerta:int}")]
        public async Task<IActionResult> Descartar([FromRoute] int idAlerta, [FromQuery] int idUsuario)
        {
            var res = await _Service.Descartar(idUsuario, idAlerta);
            return Ok(res);
        }

        [HttpGet("revisar")]
        public async Task<IActionResult> Revisar([FromQuery] int idUsuario, [FromQuery] string periodo, [FromQuery] int? idCategoria = null)
        {
            var res = await _Service.Revisar(idUsuario, periodo);
            return Ok(res);
        }
    }
}

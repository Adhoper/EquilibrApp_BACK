using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquilibrApp_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : Controller
    {
        private readonly ITransaccionService _Service;
        public TransaccionController(ITransaccionService Service)
        {
            this._Service = Service;
        }

        [HttpPost("guardar-transaccion")]
        public async Task<IActionResult> GuardarTransaccion([FromBody] SetTransaccion model)
            => Ok(await _Service.GuardarTransaccion(model));

        [HttpPut("cambiar-estatus-transaccion")]
        public async Task<IActionResult> CambiarEstatusTransaccion([FromBody] CambiarEstatusTransaccion model)
            => Ok(await _Service.CambiarEstatusTransaccion(model));

        [HttpGet("listar-transaccion")]
        public async Task<IActionResult> ListarTransaccion([FromQuery] int IdUsuario, [FromQuery] string periodo,
            [FromQuery] int? idCategoria = null, [FromQuery] int? idCuenta = null, [FromQuery] byte? tipo = null,
            [FromQuery] string? buscar = null, [FromQuery] int pagina = 1, [FromQuery] int tamPagina = 50,
            [FromQuery] bool soloActivas = true)
            => Ok(await _Service.ListarTransaccion(IdUsuario, periodo, idCategoria, idCuenta, tipo, buscar, pagina, tamPagina, soloActivas));

        [HttpGet("transacciones-por-periodo")]
        public async Task<IActionResult> TotalesPeriodo([FromQuery] int IdUsuario, [FromQuery] string periodo)
            => Ok(await _Service.TotalesPeriodo(IdUsuario, periodo));

        [HttpGet("resumen-categoria")]
        public async Task<IActionResult> ResumenCategoria([FromQuery] int IdUsuario, [FromQuery] string periodo)
            => Ok(await _Service.ResumenPorCategoria(IdUsuario, periodo));
    }
}

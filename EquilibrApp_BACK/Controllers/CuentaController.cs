using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquilibrApp_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : Controller
    {
        private readonly ICuentaService _Service;
        public CuentaController(ICuentaService Service)
        {
            this._Service = Service;
        }

        [HttpGet("listar-cuenta")]
        public async Task<IActionResult> Get([FromQuery] int IdUsuario, [FromQuery] bool soloActivas = true, [FromQuery] string? buscar = null)
            => Ok(await _Service.ListarCuenta(IdUsuario, soloActivas, buscar));

        [HttpPost("guardar-cuenta")]
        public async Task<IActionResult> Guardar([FromBody] SetCuenta model)
            => Ok(await _Service.GuardarCuenta(model));

        [HttpPut("cambiar-estatus-cuenta")]
        public async Task<IActionResult> CambiarEstatus([FromBody] CambiarEstatusCuenta model)
            => Ok(await _Service.CambiarEstatusCuenta(model));

        [HttpGet("saldos-por-periodo")]
        public async Task<IActionResult> Saldos([FromQuery] int IdUsuario, [FromQuery] string periodo, [FromQuery] int? idCuenta = null)
            => Ok(await _Service.SaldosPorPeriodo(IdUsuario, periodo, idCuenta));
    }
}

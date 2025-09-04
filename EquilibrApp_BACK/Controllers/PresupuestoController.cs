using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquilibrApp_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : Controller
    {
        private readonly IPresupuestoService _Service;
        public PresupuestoController(IPresupuestoService Service)
        {
            this._Service = Service;
        }

        [HttpGet("listar-presupuesto")]
        public async Task<IActionResult> Listar([FromQuery] int IdUsuario, [FromQuery] string periodo, [FromQuery] bool soloActivos = true)
            => Ok(await _Service.ListarPresupuesto(IdUsuario, periodo, soloActivos));

        [HttpPost("guardar-presupuesto")]
        public async Task<IActionResult> Guardar([FromBody] SetPresupuesto model)
            => Ok(await _Service.GuardarPresupuesto(model));

        [HttpPut("cambiar-estatus-presupuesto")]
        public async Task<IActionResult> CambiarEstatus([FromBody] CambiarEstatusPresupuesto model)
            => Ok(await _Service.CambiarEstatusPresupuesto(model));

        [HttpGet("uso-por-categoria-presupuesto")]
        public async Task<IActionResult> UsoPorCategoria([FromQuery] int IdUsuario, [FromQuery] string periodo)
            => Ok(await _Service.UsoPorCategoriaPresupuesto(IdUsuario, periodo));

        [HttpPost("guardar-presupuesto-global")]
        public async Task<IActionResult> GuardarGlobal([FromBody] SetPresupuestoGlobal model)
            => Ok(await _Service.GuardarGlobalPresupuesto(model));

        [HttpGet("uso-presupuesto-global")]
        public async Task<IActionResult> UsoGlobal([FromQuery] int IdUsuario, [FromQuery] string periodo)
            => Ok(await _Service.UsoGlobalPresupuesto(IdUsuario, periodo));
    }
}

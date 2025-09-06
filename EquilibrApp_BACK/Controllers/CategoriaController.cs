using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquilibrApp_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _Service;
        public CategoriaController(ICategoriaService Service)
        {
            this._Service = Service;
        }

        [HttpGet("listar-categoria")]
        public async Task<IActionResult> ListarCategoria([FromQuery] int IdUsuario, [FromQuery] byte? tipo, [FromQuery] bool soloActivas = true, [FromQuery] string? buscar = null)
        => Ok(await _Service.ListarCategoria(IdUsuario, tipo, soloActivas, buscar));

        [HttpPost("guardar-categoria")]
        public async Task<IActionResult> GuardarCategoria([FromBody] SetCategoria model)
            => Ok(await _Service.GuardarCategoria(model));


        [HttpPut("cambiar-estatus-categoria")]
        public async Task<IActionResult> CambiarEstatusCategoria([FromBody] CambiarEstatusCategoria model)
            => Ok(await _Service.CambiarEstatusCategoria(model));
    }
}

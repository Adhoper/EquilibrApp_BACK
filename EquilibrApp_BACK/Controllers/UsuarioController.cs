using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.AspNetCore.Mvc;

namespace EquilibrApp_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _Service;
        public UsuarioController(IUsuarioService Service)
        {
            this._Service = Service;
        }

        [HttpPost("set-usuario")]
        public async Task<IActionResult> SetUsuario(SetUsuario model)
        {
            return Ok(await _Service.SetUsuario(model));
        }

        [HttpPost("actualizar-usuario")]
        public async Task<IActionResult> ActualizarUsuario(UpdateUsuario model)
            => Ok(await _Service.ActualizarUsuario(model));
    }
}

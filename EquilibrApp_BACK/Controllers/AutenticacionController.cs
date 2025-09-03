using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquilibrApp_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : Controller
    {
        private readonly IAutenticacionService _Service;
        public AutenticacionController(IAutenticacionService Service)
        {
            this._Service = Service;
        }

        [HttpPost("ValidarAutenticacion")]
        public async Task<IActionResult> ValidarAutenticacion([FromBody] UsuarioLoginDTO data)
        {
            var result = await _Service.ValidarAutenticacion(data);

            // Siempre devuelve 200 OK con el resultado, aunque sea error lógico (como contraseña incorrecta)
            return Ok(result);
        }
    }
}

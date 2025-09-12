using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class UpdateUsuarioResult
    {
        public string Estado { get; set; } = "";            // OK | RECHAZADO | NO_ENCONTRADO
        public string Mensaje { get; set; } = "";
        public int? IdUsuario { get; set; }
        public string? Correo { get; set; }
        public string? Nombre { get; set; }
    }
}

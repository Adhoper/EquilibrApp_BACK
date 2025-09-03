using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class SetUserResult
    {
        public string EstatusRegistro { get; set; } = string.Empty; // CORRECTO | EXISTENTE | REACTIVADO | ERROR
        public string Result { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
    }
}

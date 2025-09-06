using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class SetPresupuestoGlobalResult
    {
        public string EstatusGuardado { get; set; } = string.Empty; // CORRECTO | ACTUALIZADO | REACTIVADO
        public string Result { get; set; } = string.Empty;
        public string Periodo { get; set; } = string.Empty;
        public decimal MontoLimiteGlobal { get; set; }
    }
}

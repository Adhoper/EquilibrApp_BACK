using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class SetPresupuestoResult
    {
        public string EstatusGuardado { get; set; } = string.Empty; // CORRECTO | ACTUALIZADO | REACTIVADO | EXISTENTE | NO_ENCONTRADO | ERROR
        public string Result { get; set; } = string.Empty;
        public int IdPresupuesto { get; set; }
        public int? IdCategoria { get; set; }
        public string? Periodo { get; set; }
        public decimal? MontoLimite { get; set; }
        public string? Estatus { get; set; }
    }
}

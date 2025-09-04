using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class UsoPresupuestoGlobalDTO
    {
        public string Periodo { get; set; } = string.Empty;
        public decimal MontoLimiteGlobal { get; set; }
        public decimal GastadoTotal { get; set; }
        public decimal DisponibleGlobal { get; set; }
        public decimal PorcentajeUsoGlobal { get; set; }
    }
}

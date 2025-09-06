using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class UsoPresupuestoDTO
    {
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;
        public decimal MontoLimite { get; set; }
        public decimal Gastado { get; set; }
        public decimal Disponible { get; set; }
        public decimal PorcentajeUso { get; set; }
        public string Estado { get; set; } = "OK"; // OK | ALERTA | CRITICO | EXCEDIDO
    }
}

using System.ComponentModel.DataAnnotations;

namespace EquilibrApp_BACK.DTO
{
    public class PresupuestoDTO
    {
        [Key]
        public int IdPresupuesto { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;
        public string Periodo { get; set; } = string.Empty;       // 'YYYY-MM'
        public decimal MontoLimite { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estatus { get; set; } = "A";
    }
}

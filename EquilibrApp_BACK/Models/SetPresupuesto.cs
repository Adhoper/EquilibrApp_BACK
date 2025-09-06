namespace EquilibrApp_BACK.Models
{
    public class SetPresupuesto
    {
        public int? IdPresupuesto { get; set; } // null=insert
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Periodo { get; set; } = string.Empty;  // 'YYYY-MM'
        public decimal MontoLimite { get; set; }
    }
}

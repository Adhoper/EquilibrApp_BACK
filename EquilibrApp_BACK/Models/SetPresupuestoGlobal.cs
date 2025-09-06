namespace EquilibrApp_BACK.Models
{
    public class SetPresupuestoGlobal
    {
        public int IdUsuario { get; set; }
        public string Periodo { get; set; } = string.Empty;  // 'YYYY-MM'
        public decimal MontoLimiteGlobal { get; set; }
    }
}

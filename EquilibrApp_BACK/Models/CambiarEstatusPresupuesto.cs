namespace EquilibrApp_BACK.Models
{
    public class CambiarEstatusPresupuesto
    {
        public int IdUsuario { get; set; }
        public int IdPresupuesto { get; set; }
        public string Estatus { get; set; } = "A"; // 'A' o 'I'
    }
}

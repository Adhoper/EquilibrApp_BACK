namespace EquilibrApp_BACK.Models
{
    public class CambiarEstatusTransaccion
    {
        public int IdUsuario { get; set; }
        public int IdTransaccion { get; set; }
        public string Estatus { get; set; } = "A";   // 'A' o 'I'
    }
}

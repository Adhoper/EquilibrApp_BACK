namespace EquilibrApp_BACK.Models
{
    public class CambiarEstatusCategoria
    {
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public string Estatus { get; set; } = "A";      // 'A' o 'I'
    }
}

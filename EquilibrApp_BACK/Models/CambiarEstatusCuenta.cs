namespace EquilibrApp_BACK.Models
{
    public class CambiarEstatusCuenta
    {
        public int IdUsuario { get; set; }
        public int IdCuenta { get; set; }
        public string Estatus { get; set; } = "A"; // 'A' o 'I'
    }
}

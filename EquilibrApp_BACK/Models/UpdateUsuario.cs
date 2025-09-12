namespace EquilibrApp_BACK.Models
{
    public class UpdateUsuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }                 
        public string? ContrasenaActual { get; set; }       
        public string? ContrasenaNueva { get; set; }
    }
}

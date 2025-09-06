namespace EquilibrApp_BACK.Models
{
    public class SetCategoria
    {
        public int? IdCategoria { get; set; }           // null = crear, valor = actualizar
        public int IdUsuario { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;
        public byte TipoCategoria { get; set; }         // 0/1
        public string? ColorHexadecimal { get; set; }   // "#22C55E"
    }
}

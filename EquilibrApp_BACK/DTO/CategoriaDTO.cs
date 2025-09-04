using System.ComponentModel.DataAnnotations;

namespace EquilibrApp_BACK.DTO
{
    public class CategoriaDTO
    {
        [Key]
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;
        public byte TipoCategoria { get; set; }     // 0=Gasto,1=Ingreso
        public string? ColorHexadecimal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estatus { get; set; } = "A";  // 'A'/'I'
    }
}

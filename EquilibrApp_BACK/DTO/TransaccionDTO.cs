using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EquilibrApp_BACK.DTO
{
    public class TransaccionDTO
    {
        [Key]
        public int IdTransaccion { get; set; }
        public int IdUsuario { get; set; }
        public int IdCuenta { get; set; }
        public string NombreCuenta { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;
        public byte TipoTransaccion { get; set; }        // 0/1
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string? Nota { get; set; }
        public string Estatus { get; set; } = "A";
    }
}

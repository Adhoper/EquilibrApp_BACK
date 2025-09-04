using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class SetTransaccionResult
    {
        public string EstatusGuardado { get; set; } = string.Empty; // CORRECTO | ACTUALIZADO | NO_ENCONTRADA | ERROR
        public string Result { get; set; } = string.Empty;
        public int IdTransaccion { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCuenta { get; set; }
        public int? IdCategoria { get; set; }
        public byte? TipoTransaccion { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? FechaTransaccion { get; set; }
        public string? Nota { get; set; }
        public string? Estatus { get; set; }
    }
}

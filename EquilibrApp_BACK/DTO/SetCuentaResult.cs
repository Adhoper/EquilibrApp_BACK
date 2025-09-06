using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class SetCuentaResult
    {
        public string EstatusGuardado { get; set; } = string.Empty; // CORRECTO | ACTUALIZADO | REACTIVADA | EXISTENTE | NO_ENCONTRADA | ERROR
        public string Result { get; set; } = string.Empty;
        public int IdCuenta { get; set; }
        public string? NombreCuenta { get; set; }
        public string? CodigoMoneda { get; set; }
        public decimal? SaldoInicial { get; set; }
        public string? Estatus { get; set; }
    }
}

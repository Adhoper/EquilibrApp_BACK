using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class CuentaSaldoDTO
    {
        public int IdCuenta { get; set; }
        public string NombreCuenta { get; set; } = string.Empty;
        public string CodigoMoneda { get; set; } = "DOP";
        public decimal SaldoInicial { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Gastos { get; set; }
        public decimal Saldo { get; set; }
    }
}

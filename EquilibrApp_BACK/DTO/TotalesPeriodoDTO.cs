using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class TotalesPeriodoDTO
    {
        public decimal TotalGastos { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal Balance { get; set; }
    }
}

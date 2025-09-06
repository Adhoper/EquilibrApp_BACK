using System.ComponentModel.DataAnnotations;

namespace EquilibrApp_BACK.DTO
{
    public class CuentaDTO
    {
        [Key]
        public int IdCuenta { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCuenta { get; set; } = string.Empty;
        public string CodigoMoneda { get; set; } = "DOP";
        public decimal SaldoInicial { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estatus { get; set; } = "A";
    }
}

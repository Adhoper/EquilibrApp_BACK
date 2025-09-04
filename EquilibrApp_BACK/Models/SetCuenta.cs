namespace EquilibrApp_BACK.Models
{
    public class SetCuenta
    {
        public int? IdCuenta { get; set; }         // null = crear; valor = actualizar
        public int IdUsuario { get; set; }
        public string NombreCuenta { get; set; } = string.Empty;
        public string CodigoMoneda { get; set; } = "DOP";
        public decimal SaldoInicial { get; set; } = 0;
    }
}

namespace EquilibrApp_BACK.Models
{
    public class SetTransaccion
    {
        public int? IdTransaccion { get; set; }      // null = crear; valor = actualizar
        public int IdUsuario { get; set; }
        public int IdCuenta { get; set; }
        public int IdCategoria { get; set; }
        public byte TipoTransaccion { get; set; }    // 0/1
        public decimal Monto { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string? Nota { get; set; }
    }
}

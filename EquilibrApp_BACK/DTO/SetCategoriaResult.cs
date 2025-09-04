using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class SetCategoriaResult
    {
        public string EstatusGuardado { get; set; } = string.Empty; // CORRECTO | ACTUALIZADO | REACTIVADA | EXISTENTE | NO_ENCONTRADA | ERROR
        public string Result { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
        public byte? TipoCategoria { get; set; }
        public string? ColorHexadecimal { get; set; }
        public string? Estatus { get; set; }
    }
}

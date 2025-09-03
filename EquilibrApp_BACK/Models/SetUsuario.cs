using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.Models
{
    public class SetUsuario
    {
        public string Nombre { get; set; } = string.Empty;   // NombreMostrar
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty; // texto plano; se hashea en el service
    }
}

using System.ComponentModel.DataAnnotations;

namespace EquilibrApp_BACK.DTO
{
    public class LoginUsuarioInfo
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public Byte[] ContrasenaHash { get; set; }
        public string Nombre { get; set; }
    }
}

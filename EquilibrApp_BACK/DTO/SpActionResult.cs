using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.DTO
{
    [Keyless]
    public class SpActionResult
    {
        public string EstatusRegistro { get; set; }
        public string Result { get; set; }
    }
}

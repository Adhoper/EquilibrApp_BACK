using EquilibrApp_BACK.DTO;
using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.Context
{
    public class EquilibrAppContext : DbContext
    {
        public EquilibrAppContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<LoginUsuarioInfo> LoginUsuario { get; set; }
        public DbSet<SetUserResult> SetUserResult { get; set; }
    }
}

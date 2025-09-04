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
        public DbSet<CategoriaDTO> CategoriaDTO { get; set; }
        public DbSet<SetCategoriaResult> SetCategoriaResult { get; set; }
        public DbSet<CuentaDTO> CuentaDTO { get; set; } = null!;
        public DbSet<SetCuentaResult> SetCuentaResult { get; set; } = null!;
        public DbSet<CuentaSaldoDTO> CuentaSaldoDTO { get; set; } = null!;
        public DbSet<SetTransaccionResult> SetTransaccionResult { get; set; } = null!;
        public DbSet<TransaccionDTO> TransaccionesList { get; set; } = null!;
        public DbSet<TotalesPeriodoDTO> TotalesPeriodo { get; set; } = null!;
        public DbSet<ResumenCategoriaDTO> ResumenCategoria { get; set; } = null!;
        public DbSet<PresupuestoDTO> PresupuestosList { get; set; } = null!;
        public DbSet<SetPresupuestoResult> SetPresupuestoResult { get; set; } = null!;
        public DbSet<UsoPresupuestoDTO> UsoPresupuesto { get; set; } = null!;
        public DbSet<SetPresupuestoGlobalResult> SetPresupuestoGlobalResult { get; set; } = null!;
        public DbSet<UsoPresupuestoGlobalDTO> UsoPresupuestoGlobal { get; set; } = null!;
    }
}

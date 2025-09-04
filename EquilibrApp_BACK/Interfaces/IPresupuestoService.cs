using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Models;

namespace EquilibrApp_BACK.Interfaces
{
    public interface IPresupuestoService
    {
        Task<Response<PresupuestoDTO>> ListarPresupuesto(int idUsuario, string periodo, bool soloActivos);
        Task<Response<SetPresupuestoResult>> GuardarPresupuesto(SetPresupuesto model);
        Task<Response<SetPresupuestoResult>> CambiarEstatusPresupuesto(CambiarEstatusPresupuesto model);
        Task<Response<UsoPresupuestoDTO>> UsoPorCategoriaPresupuesto(int idUsuario, string periodo);

        Task<Response<SetPresupuestoGlobalResult>> GuardarGlobalPresupuesto(SetPresupuestoGlobal model);
        Task<Response<UsoPresupuestoGlobalDTO>> UsoGlobalPresupuesto(int idUsuario, string periodo);
    }
}

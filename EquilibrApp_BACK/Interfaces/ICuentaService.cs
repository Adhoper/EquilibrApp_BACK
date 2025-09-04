using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Models;

namespace EquilibrApp_BACK.Interfaces
{
    public interface ICuentaService
    {
        Task<Response<CuentaDTO>> ListarCuenta(int idUsuario, bool soloActivas, string? buscar);
        Task<Response<SetCuentaResult>> GuardarCuenta(SetCuenta model);
        Task<Response<SetCuentaResult>> CambiarEstatusCuenta(CambiarEstatusCuenta model);
        Task<Response<CuentaSaldoDTO>> SaldosPorPeriodo(int idUsuario, string periodo, int? idCuenta);
    }
}

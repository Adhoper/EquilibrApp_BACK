using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Models;

namespace EquilibrApp_BACK.Interfaces
{
    public interface ITransaccionService
    {
        Task<Response<SetTransaccionResult>> GuardarTransaccion(SetTransaccion model);
        Task<Response<SetTransaccionResult>> CambiarEstatusTransaccion(CambiarEstatusTransaccion model);
        Task<Response<TransaccionDTO>> ListarTransaccion(int idUsuario, string periodo, int? idCategoria, int? idCuenta, byte? tipo, string? buscar, int pagina, int tamPagina, bool soloActivas);
        Task<Response<TotalesPeriodoDTO>> TotalesPeriodo(int idUsuario, string periodo);
        Task<Response<ResumenCategoriaDTO>> ResumenPorCategoria(int idUsuario, string periodo);
    }
}

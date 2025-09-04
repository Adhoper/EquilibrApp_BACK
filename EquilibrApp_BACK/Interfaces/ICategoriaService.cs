using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Models;

namespace EquilibrApp_BACK.Interfaces
{
    public interface ICategoriaService
    {
        Task<Response<CategoriaDTO>> ListarCategoria(int idUsuario, byte? tipo, bool soloActivas, string? buscar);
        Task<Response<SetCategoriaResult>> GuardarCategoria(SetCategoria model);
        Task<Response<SetCategoriaResult>> CambiarEstatusCategoria(CambiarEstatusCategoria model);
    }
}

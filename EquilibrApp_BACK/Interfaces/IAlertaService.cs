using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Models;

namespace EquilibrApp_BACK.Interfaces
{
    public interface IAlertaService
    {
        Task<Response<AlertaItem>> Listar(int idUsuario, string periodo, string estado = null);
        Task<Response> MarcarLeida(int idUsuario, int idAlerta);
        Task<Response> MarcarTodas(int idUsuario, string periodo);
        Task<Response> Descartar(int idUsuario, int idAlerta);
        Task<Response<AlertaItem>> Revisar(int idUsuario, string periodo, int? idCategoria = null);
    }
}

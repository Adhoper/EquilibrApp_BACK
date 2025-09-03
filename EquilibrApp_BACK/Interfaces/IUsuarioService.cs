using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Models;

namespace EquilibrApp_BACK.Interfaces
{
    public interface IUsuarioService
    {
        Task<Response<SetUserResult>> SetUsuario(SetUsuario setUsuario);
    }
}

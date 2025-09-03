using EquilibrApp_BACK.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EquilibrApp_BACK.Interfaces
{
    public interface IAutenticacionService
    {
        Task<Response<LoginUsuarioInfo>> LoginUsuario(string identificadorUsuario);
        Task<Response> ValidarAutenticacion([FromBody] UsuarioLoginDTO data);
    }
}

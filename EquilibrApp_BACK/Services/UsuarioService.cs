using EquilibrApp_BACK.Context;
using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly EquilibrAppContext _context;
        public UsuarioService(EquilibrAppContext context)
        {
            this._context = context;
        }

        public async Task<Response<SetUserResult>> SetUsuario(SetUsuario model)
        {
            var result = new Response<SetUserResult>(); 
            var passHash = Utilidades.HashPassword(model.Contrasena);

            try
            {
                var filas = await _context.SetUserResult
                    .FromSqlInterpolated($@"
                     dbo.SetUsuario
                     @Nombre={model.Nombre},
                     @Correo={model.Correo},
                     @ContrasenaHash={passHash}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                result.SingleData = row;

                if (row is null)
                {
                    result.Successful = false;
                    result.Message = "Sin respuesta del servidor.";
                    return result;
                }

                // Tu mensaje propio según estatus devuelto por el SP
                result.Message = row.EstatusRegistro switch
                {
                    "CORRECTO" => "Usuario registrado correctamente.",
                    "REACTIVADO" => "Cuenta reactivada con éxito.",
                    "EXISTENTE" => "El correo ya está registrado.",
                    _ => "No se pudo registrar el usuario."
                };

                result.Successful = row.EstatusRegistro is "CORRECTO" or "REACTIVADO";
                result.EntityId = row.IdUsuario;
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Message = "No se ha podido registrar sus datos";
                result.Errors.Add(ex.Message);
            }

            return result;
        }

    }
}

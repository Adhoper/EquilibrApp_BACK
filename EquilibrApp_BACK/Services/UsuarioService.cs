using EquilibrApp_BACK.Context;
using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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


        public async Task<Response<UpdateUsuarioResult>> ActualizarUsuario(UpdateUsuario model)
        {
            var resp = new Response<UpdateUsuarioResult>();

            // Hashes solo si quiere cambiar la contraseña
            byte[]? hashActual = null;
            byte[]? hashNueva = null;

            if (!string.IsNullOrWhiteSpace(model.ContrasenaNueva))
            {
                if (string.IsNullOrWhiteSpace(model.ContrasenaActual))
                {
                    resp.Successful = false;
                    resp.Message = "Debes confirmar la contraseña actual.";
                    return resp;
                }

                hashActual = Utilidades.HashPassword(model.ContrasenaActual!);
                hashNueva = Utilidades.HashPassword(model.ContrasenaNueva!);
            }

            // Parámetros tipados (clave para evitar la conversión nvarchar→varbinary)
            var pId = new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = model.IdUsuario };
            var pNombre = new SqlParameter("@Nombre", SqlDbType.NVarChar, 120)
            {
                IsNullable = true,
                Value = string.IsNullOrWhiteSpace(model.Nombre) ? DBNull.Value : model.Nombre!.Trim()
            };
            var pNueva = new SqlParameter("@ContrasenaNuevaHash", SqlDbType.VarBinary, 256)
            {
                IsNullable = true,
                Value = (object?)hashNueva ?? DBNull.Value
            };
            var pActual = new SqlParameter("@ContrasenaActualHash", SqlDbType.VarBinary, 256)
            {
                IsNullable = true,
                Value = (object?)hashActual ?? DBNull.Value
            };

            try
            {
                // Usa FromSqlRaw/Interpolated con parámetros tipados
                var filas = await _context.UpdateUsuarioResult
                    .FromSqlRaw(
                        "EXEC dbo.ActualizarUsuario @IdUsuario, @Nombre, @ContrasenaNuevaHash, @ContrasenaActualHash",
                        pId, pNombre, pNueva, pActual)
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                resp.SingleData = row;

                if (row is null)
                {
                    resp.Successful = false;
                    resp.Message = "Sin respuesta del servidor.";
                    return resp;
                }

                resp.Successful = row.Estado == "OK";
                resp.Message = row.Mensaje;
                resp.EntityId = (long)row.IdUsuario;
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo actualizar el perfil.";
                resp.Errors.Add(ex.Message);
            }

            return resp;
        }
    }

}

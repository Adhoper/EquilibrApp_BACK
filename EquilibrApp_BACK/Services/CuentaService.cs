using EquilibrApp_BACK.Context;
using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly EquilibrAppContext _context;
        public CuentaService(EquilibrAppContext context)
        {
            this._context = context;
        }

        public async Task<Response<SetCuentaResult>> CambiarEstatusCuenta(CambiarEstatusCuenta model)
        {
            var resp = new Response<SetCuentaResult>();
            try
            {
                var filas = await _context.SetCuentaResult.FromSqlInterpolated($@"
                EXEC dbo.Cuenta_CambiarEstatus
                     @IdUsuario={model.IdUsuario},
                     @IdCuenta={model.IdCuenta},
                     @Estatus={model.Estatus}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                resp.SingleData = row;

                if (row is null)
                {
                    resp.Successful = false;
                    resp.Message = "Sin respuesta del servidor.";
                    resp.Errors.Add("SP Cuenta_CambiarEstatus no retornó filas.");
                    return resp;
                }

                resp.Successful = row.EstatusGuardado is "ACTUALIZADO";
                resp.Message = row.Result;
                resp.EntityId = row.IdCuenta;
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo actualizar el estatus";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<SetCuentaResult>> GuardarCuenta(SetCuenta model)
        {
            var resp = new Response<SetCuentaResult>();
            try
            {
                var filas = await _context.SetCuentaResult.FromSqlInterpolated($@"
                     dbo.Cuenta_Guardar
                     @IdUsuario={model.IdUsuario},
                     @IdCuenta={model.IdCuenta},
                     @NombreCuenta={model.NombreCuenta},
                     @CodigoMoneda={model.CodigoMoneda},
                     @SaldoInicial={model.SaldoInicial}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                resp.SingleData = row;

                if (row is null)
                {
                    resp.Successful = false;
                    resp.Message = "Sin respuesta del servidor.";
                    resp.Errors.Add("SP Cuenta_Guardar no retornó filas.");
                    return resp;
                }

                resp.Successful = row.EstatusGuardado is "CORRECTO" or "ACTUALIZADO" or "REACTIVADA";
                resp.Message = row.Result;
                resp.EntityId = row.IdCuenta;
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo guardar la cuenta";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<CuentaDTO>> ListarCuenta(int idUsuario, bool soloActivas, string? buscar)
        {
            var resp = new Response<CuentaDTO>();
            try
            {
                var filas = await _context.CuentaDTO.FromSqlInterpolated($@"
                     dbo.Cuenta_Listar
                     @IdUsuario={idUsuario},
                     @SoloActivas={(soloActivas ? 1 : 0)},
                     @Buscar={buscar}")
                    .ToListAsync();

                resp.DataList = filas;
                resp.Successful = true;
                resp.Message = "OK";
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "Error al listar cuentas";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<CuentaSaldoDTO>> SaldosPorPeriodo(int idUsuario, string periodo, int? idCuenta)
        {
            var resp = new Response<CuentaSaldoDTO>();
            try
            {
                var filas = await _context.CuentaSaldoDTO.FromSqlInterpolated($@"
                     dbo.Cuenta_SaldoPorPeriodo
                     @IdUsuario={idUsuario},
                     @Periodo={periodo},
                     @IdCuenta={idCuenta}")
                    .ToListAsync();

                resp.DataList = filas;
                resp.Successful = true;
                resp.Message = "OK";
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "Error al obtener saldos";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }
    }
}

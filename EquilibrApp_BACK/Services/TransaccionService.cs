using EquilibrApp_BACK.Context;
using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.Services
{
    public class TransaccionService : ITransaccionService
    {
        private readonly EquilibrAppContext _context;
        public TransaccionService(EquilibrAppContext context)
        {
            this._context = context;
        }

        public async Task<Response<SetTransaccionResult>> GuardarTransaccion(SetTransaccion model)
        {
            var resp = new Response<SetTransaccionResult>();
            try
            {
                var filas = await _context.SetTransaccionResult.FromSqlInterpolated($@"
                EXEC dbo.Transaccion_Guardar
                     @IdUsuario={model.IdUsuario},
                     @IdTransaccion={model.IdTransaccion},
                     @IdCuenta={model.IdCuenta},
                     @IdCategoria={model.IdCategoria},
                     @TipoTransaccion={model.TipoTransaccion},
                     @Monto={model.Monto},
                     @FechaTransaccion={model.FechaTransaccion},
                     @Nota={model.Nota}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                resp.SingleData = row;

                if (row is null)
                {
                    resp.Successful = false;
                    resp.Message = "Sin respuesta del servidor.";
                    resp.Errors.Add("SP Transaccion_Guardar no retornó filas.");
                    return resp;
                }

                resp.Successful = row.EstatusGuardado is "CORRECTO" or "ACTUALIZADO";
                resp.Message = row.Result;
                resp.EntityId = row.IdTransaccion;
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo guardar la transacción";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<SetTransaccionResult>> CambiarEstatusTransaccion(CambiarEstatusTransaccion model)
        {
            var resp = new Response<SetTransaccionResult>();
            try
            {
                var filas = await _context.SetTransaccionResult.FromSqlInterpolated($@"
                EXEC dbo.Transaccion_CambiarEstatus
                     @IdUsuario={model.IdUsuario},
                     @IdTransaccion={model.IdTransaccion},
                     @Estatus={model.Estatus}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                resp.SingleData = row;

                if (row is null)
                {
                    resp.Successful = false;
                    resp.Message = "Sin respuesta del servidor.";
                    resp.Errors.Add("SP Transaccion_CambiarEstatus no retornó filas.");
                    return resp;
                }

                resp.Successful = row.EstatusGuardado is "ACTUALIZADO";
                resp.Message = row.Result;
                resp.EntityId = model.IdTransaccion;
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo actualizar el estatus";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<TransaccionDTO>> ListarTransaccion(int idUsuario, string periodo, int? idCategoria, int? idCuenta, byte? tipo,
        string? buscar, int pagina, int tamPagina, bool soloActivas)
        {
            var resp = new Response<TransaccionDTO>();
            try
            {
                var filas = await _context.TransaccionesList.FromSqlInterpolated($@"
                     dbo.Transaccion_Listar
                     @IdUsuario={idUsuario},
                     @Periodo={periodo},
                     @IdCategoria={idCategoria},
                     @IdCuenta={idCuenta},
                     @TipoTransaccion={tipo},
                     @Buscar={buscar},
                     @Pagina={pagina},
                     @TamPagina={tamPagina},
                     @SoloActivas={(soloActivas ? 1 : 0)}")
                    .ToListAsync();

                resp.DataList = filas;
                resp.Successful = true;
                resp.Message = "OK";
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "Error al listar transacciones";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<TotalesPeriodoDTO>> TotalesPeriodo(int idUsuario, string periodo)
        {
            var resp = new Response<TotalesPeriodoDTO>();
            try
            {
                var filas = await _context.TotalesPeriodo.FromSqlInterpolated($@"
                EXEC dbo.Transaccion_TotalesPeriodo
                     @IdUsuario={idUsuario},
                     @Periodo={periodo}")
                    .ToListAsync();

                resp.SingleData = filas.FirstOrDefault();
                resp.Successful = true;
                resp.Message = "OK";
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "Error al obtener totales";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<ResumenCategoriaDTO>> ResumenPorCategoria(int idUsuario, string periodo)
        {
            var resp = new Response<ResumenCategoriaDTO> { DataList = new List<ResumenCategoriaDTO>() };
            try
            {
                var filas = await _context.ResumenCategoria.FromSqlInterpolated($@"
                EXEC dbo.Transaccion_ResumenPorCategoria
                     @IdUsuario={idUsuario},
                     @Periodo={periodo}")
                    .ToListAsync();

                resp.DataList = filas;
                resp.Successful = true;
                resp.Message = "OK";
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "Error al obtener resumen por categoría";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }
    }
}

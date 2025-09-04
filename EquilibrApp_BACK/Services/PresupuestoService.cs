using EquilibrApp_BACK.Context;
using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.Services
{
    public class PresupuestoService : IPresupuestoService
    {
        private readonly EquilibrAppContext _context;
        public PresupuestoService(EquilibrAppContext context)
        {
            this._context = context;
        }

        public async Task<Response<PresupuestoDTO>> ListarPresupuesto(int idUsuario, string periodo, bool soloActivos)
        {
            var resp = new Response<PresupuestoDTO> { DataList = new List<PresupuestoDTO>() };
            try
            {
                var filas = await _context.PresupuestosList.FromSqlInterpolated($@"
                     dbo.Presupuesto_Listar
                     @IdUsuario={idUsuario},
                     @Periodo={periodo},
                     @SoloActivos={(soloActivos ? 1 : 0)}")
                    .ToListAsync();

                resp.DataList = filas;
                resp.Successful = true;
                resp.Message = "OK";
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "Error al listar presupuestos";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<SetPresupuestoResult>> GuardarPresupuesto(SetPresupuesto model)
        {
            var resp = new Response<SetPresupuestoResult>();
            try
            {
                var filas = await _context.SetPresupuestoResult.FromSqlInterpolated($@"
                     dbo.Presupuesto_Guardar
                     @IdUsuario={model.IdUsuario},
                     @IdPresupuesto={model.IdPresupuesto},
                     @IdCategoria={model.IdCategoria},
                     @Periodo={model.Periodo},
                     @MontoLimite={model.MontoLimite}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                resp.SingleData = row;

                if (row is null)
                {
                    resp.Successful = false;
                    resp.Message = "Sin respuesta del servidor.";
                    resp.Errors.Add("SP Presupuesto_Guardar no retornó filas.");
                    return resp;
                }

                resp.Successful = row.EstatusGuardado is "CORRECTO" or "ACTUALIZADO" or "REACTIVADO";
                resp.Message = row.Result;
                resp.EntityId = row.IdPresupuesto;
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo guardar el presupuesto";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<SetPresupuestoResult>> CambiarEstatusPresupuesto(CambiarEstatusPresupuesto model)
        {
            var resp = new Response<SetPresupuestoResult>();
            try
            {
                var filas = await _context.SetPresupuestoResult.FromSqlInterpolated($@"
                     dbo.Presupuesto_CambiarEstatus
                     @IdUsuario={model.IdUsuario},
                     @IdPresupuesto={model.IdPresupuesto},
                     @Estatus={model.Estatus}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                resp.SingleData = row;

                if (row is null)
                {
                    resp.Successful = false;
                    resp.Message = "Sin respuesta del servidor.";
                    resp.Errors.Add("SP Presupuesto_CambiarEstatus no retornó filas.");
                    return resp;
                }

                resp.Successful = row.EstatusGuardado is "ACTUALIZADO";
                resp.Message = row.Result;
                resp.EntityId = model.IdPresupuesto;
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo actualizar el estatus";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<UsoPresupuestoDTO>> UsoPorCategoriaPresupuesto(int idUsuario, string periodo)
        {
            var resp = new Response<UsoPresupuestoDTO> { DataList = new List<UsoPresupuestoDTO>() };
            try
            {
                var filas = await _context.UsoPresupuesto.FromSqlInterpolated($@"
                     dbo.Presupuesto_UsoPorCategoria
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
                resp.Message = "Error al calcular uso por categoría";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<SetPresupuestoGlobalResult>> GuardarGlobalPresupuesto(SetPresupuestoGlobal model)
        {
            var resp = new Response<SetPresupuestoGlobalResult>();
            try
            {
                var filas = await _context.SetPresupuestoGlobalResult.FromSqlInterpolated($@"
                     dbo.PresupuestoGlobal_Guardar
                     @IdUsuario={model.IdUsuario},
                     @Periodo={model.Periodo},
                     @MontoLimiteGlobal={model.MontoLimiteGlobal}")
                    .ToListAsync();

                resp.SingleData = filas.FirstOrDefault();
                resp.Successful = resp.SingleData != null;
                resp.Message = resp.SingleData?.Result ?? "Sin respuesta del servidor.";
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo guardar el presupuesto global";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<UsoPresupuestoGlobalDTO>> UsoGlobalPresupuesto(int idUsuario, string periodo)
        {
            var resp = new Response<UsoPresupuestoGlobalDTO>();
            try
            {
                var filas = await _context.UsoPresupuestoGlobal.FromSqlInterpolated($@"
                     dbo.PresupuestoGlobal_Uso
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
                resp.Message = "Error al calcular uso global";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }
    }
}

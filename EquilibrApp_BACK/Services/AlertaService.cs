using EquilibrApp_BACK.Context;
using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.Services
{
    public class AlertaService : IAlertaService
    {
        private readonly EquilibrAppContext _context;
        public AlertaService(EquilibrAppContext context)
        {
            this._context = context;
        }

        public async Task<Response<AlertaItem>> Listar(int idUsuario, string periodo, string estado = null)
        {
            var r = new Response<AlertaItem>();
            try
            {
                var filas = await _context.AlertaItems
                    .FromSqlInterpolated($"dbo.Alerta_Listar {idUsuario}, {periodo}, {estado}")
                    .ToListAsync();

                r.DataList = filas;
                r.Successful = true;
                r.Message = $"Total: {filas.Count}";
            }
            catch (Exception ex)
            {
                r.Successful = false;
                r.Message = "No se pudo listar las alertas";
                r.Errors.Add(ex.Message);
            }
            return r;
        }

        public async Task<Response> MarcarLeida(int idUsuario, int idAlerta)
        {
            var r = new Response();
            try
            {
                var filas = await _context.SpActionResults
                    .FromSqlInterpolated($"dbo.Alerta_MarcarLeida {idAlerta}, {idUsuario}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                r.Successful = row?.EstatusRegistro == "CORRECTO";
                r.Message = row?.Result ?? (r.Successful ? "Alerta marcada" : "No se pudo marcar la alerta");
            }
            catch (Exception ex)
            {
                r.Successful = false;
                r.Message = "Error al marcar alerta";
                r.Errors.Add(ex.Message);
            }
            return r;
        }

        public async Task<Response> MarcarTodas(int idUsuario, string periodo)
        {
            var r = new Response();
            try
            {
                var filas = await _context.SpActionResults
                    .FromSqlInterpolated($"dbo.Alerta_MarcarTodas {idUsuario}, {periodo}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                r.Successful = row?.EstatusRegistro == "CORRECTO";
                r.Message = row?.Result ?? "Operación realizada";
            }
            catch (Exception ex)
            {
                r.Successful = false;
                r.Message = "Error al marcar todas las alertas";
                r.Errors.Add(ex.Message);
            }
            return r;
        }

        public async Task<Response> Descartar(int idUsuario, int idAlerta)
        {
            var r = new Response();
            try
            {
                var filas = await _context.SpActionResults
                    .FromSqlInterpolated($"dbo.Alerta_Descartar {idAlerta}, {idUsuario}")
                    .ToListAsync();

                var row = filas.FirstOrDefault();
                r.Successful = row?.EstatusRegistro == "CORRECTO";
                r.Message = row?.Result ?? (r.Successful ? "Alerta descartada" : "No se pudo descartar la alerta");
            }
            catch (Exception ex)
            {
                r.Successful = false;
                r.Message = "Error al descartar alerta";
                r.Errors.Add(ex.Message);
            }
            return r;
        }

        public async Task<Response<AlertaItem>> Revisar(int idUsuario, string periodo, int? idCategoria = null)
        {
            var r = new Response<AlertaItem>();
            try
            {
                var filas = await _context.AlertaItems
                    .FromSqlInterpolated($"dbo.Alerta_Revisar {idUsuario}, {periodo}, {idCategoria}")
                    .ToListAsync();

                r.DataList = filas;
                r.Successful = true;
                r.Message = $"Total: {filas.Count}";
            }
            catch (Exception ex)
            {
                r.Successful = false;
                r.Message = "No se pudo revisar/generar las alertas";
                r.Errors.Add(ex.Message);
            }
            return r;
        }


    }
}

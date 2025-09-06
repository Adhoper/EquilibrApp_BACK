using EquilibrApp_BACK.Context;
using EquilibrApp_BACK.DTO;
using EquilibrApp_BACK.Interfaces;
using EquilibrApp_BACK.Models;
using Microsoft.EntityFrameworkCore;

namespace EquilibrApp_BACK.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly EquilibrAppContext _context;
        public CategoriaService(EquilibrAppContext context)
        {
            this._context = context;
        }

        public async Task<Response<CategoriaDTO>> ListarCategoria(int idUsuario, byte? tipo, bool soloActivas, string? buscar)
        {
            var resp = new Response<CategoriaDTO> { DataList = new List<CategoriaDTO>() };
            try
            {
                var filas = await _context.CategoriaDTO.FromSqlInterpolated($@"
                         dbo.Categoria_Listar
                         @IdUsuario={idUsuario},
                         @Tipo={tipo},
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
                resp.Message = "Error al listar categorías";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<SetCategoriaResult>> GuardarCategoria(SetCategoria model)
        {
            var resp = new Response<SetCategoriaResult>();
            try
            {
                var filas = await _context.SetCategoriaResult.FromSqlInterpolated($@"
                     dbo.Categoria_Guardar
                     @IdUsuario={model.IdUsuario},
                     @IdCategoria={model.IdCategoria},
                     @NombreCategoria={model.NombreCategoria},
                     @TipoCategoria={model.TipoCategoria},
                     @ColorHexadecimal={model.ColorHexadecimal}")
                .ToListAsync();

                var row = filas.FirstOrDefault();
                resp.SingleData = row;

                if (row is null)
                {
                    resp.Successful = false;
                    resp.Message = "Sin respuesta del servidor.";
                    resp.Errors.Add("SP Categoria_Guardar no retornó filas.");
                    return resp;
                }

                resp.Successful = row.EstatusGuardado is "CORRECTO" or "ACTUALIZADO" or "REACTIVADA";
                resp.Message = row.Result;
                resp.EntityId = row.IdCategoria;
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo guardar la categoría";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }

        public async Task<Response<SetCategoriaResult>> CambiarEstatusCategoria(CambiarEstatusCategoria model)
        {
            var resp = new Response<SetCategoriaResult>();
            try
            {
                var filas = await _context.SetCategoriaResult.FromSqlInterpolated($@"
                    dbo.Categoria_CambiarEstatus
                     @IdUsuario={model.IdUsuario},
                     @IdCategoria={model.IdCategoria},
                     @Estatus={model.Estatus}")
                .ToListAsync();

                var row = filas.FirstOrDefault();
                resp.SingleData = row;

                if (row is null)
                {
                    resp.Successful = false;
                    resp.Message = "Sin respuesta del servidor.";
                    resp.Errors.Add("SP Categoria_CambiarEstatus no retornó filas.");
                    return resp;
                }

                resp.Successful = row.EstatusGuardado is "ACTUALIZADO";
                resp.Message = row.Result;
                resp.EntityId = row.IdCategoria;
            }
            catch (Exception ex)
            {
                resp.Successful = false;
                resp.Message = "No se pudo actualizar el estatus";
                resp.Errors.Add(ex.Message);
            }
            return resp;
        }
    }
}

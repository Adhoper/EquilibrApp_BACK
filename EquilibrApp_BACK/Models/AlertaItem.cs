using System.ComponentModel.DataAnnotations;

namespace EquilibrApp_BACK.Models
{
    public class AlertaItem
    {
        [Key]
        public int IdAlerta { get; set; }
        public string Tipo { get; set; }          // 'C' | 'G'
        public int? IdCategoria { get; set; }
        public string? Categoria { get; set; }
        public int Umbral { get; set; }
        public decimal Porcentaje { get; set; }
        public string Estado { get; set; }        // 'N' | 'L' | 'D'
        public DateTime? FechaCreacion { get; set; }
    }
}

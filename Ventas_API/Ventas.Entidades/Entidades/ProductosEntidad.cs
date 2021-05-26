using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades.Entidades
{
    public class ProductosEntidad
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor a 1")]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "El costo debe ser mayor a 1")]
        public decimal Costo { get; set; }
    }
}

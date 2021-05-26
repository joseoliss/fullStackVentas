using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades.Entidades
{
    public class ConceptoEntidad
    {
        public long Id { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Debe existir una cantidad")]
        public int Cantidad { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Debe existir un precio unitario")]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Debe existir un importe")]
        public decimal Importe { get; set; }//total de cantidad + precioUnitario

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Debe existir un id de producto")]
        public int IdProducto { get; set; }

        public long IdVenta { get; set; }
    }
}

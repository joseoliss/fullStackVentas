using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Entidades.Entidades
{
    public class VentaEntidad
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "El cliente no puede ser nulo")]
        [Range(1, double.MaxValue, ErrorMessage = "El valor de id cliente debe ser mayor a 0")]
        public int IdCliente { get; set; }

        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Deben existir conceptos")]
        public List<ConceptoEntidad> Conceptos { get; set; }

        public VentaEntidad()
        {
            this.Conceptos = new List<ConceptoEntidad>();
        }
    }


}

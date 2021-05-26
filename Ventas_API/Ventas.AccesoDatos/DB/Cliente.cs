using System;
using System.Collections.Generic;

#nullable disable

namespace Ventas.AccesoDatos.DB
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}

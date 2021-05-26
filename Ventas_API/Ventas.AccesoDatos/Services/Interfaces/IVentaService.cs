using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Entidades.Entidades;

namespace Ventas.AccesoDatos.Services.Interfaces
{
    public interface IVentaService
    {
        public void AddVenta(VentaEntidad oVenta);
        public List<VentaEntidad> LstVenta();
    }
}

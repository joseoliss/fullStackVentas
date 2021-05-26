using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Entidades.Entidades;

namespace Ventas.AccesoDatos.Services.Interfaces
{
    public interface IProductoService
    {
        public List<ProductosEntidad> LstProducto();
        public void AddProducto(ProductosEntidad oProducto);
        public List<ProductosEntidad> FillProducto(string nombre);
        public void UpdProducto(ProductosEntidad oProducto);
        public void DelProducto(int id);        
    }
}

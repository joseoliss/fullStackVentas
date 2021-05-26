using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.AccesoDatos.DB;
using Ventas.AccesoDatos.Services.Interfaces;
using Ventas.Entidades.Entidades;

namespace Ventas.AccesoDatos.Services.Contracts
{
    public class ProductoService : IProductoService
    {
        public List<ProductosEntidad> LstProducto()
        {
            List<ProductosEntidad> lstProducto = new List<ProductosEntidad>();

            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var productos = (from d in db.Productos
                                    select d).ToList();
                    foreach (var producto in productos)
                    {
                        ProductosEntidad oProducto = new ProductosEntidad();
                        oProducto.Id = producto.Id;
                        oProducto.Nombre = producto.Nombre;
                        oProducto.PrecioUnitario = producto.PrecioUnitario;
                        oProducto.Costo = producto.Costo;
                        lstProducto.Add(oProducto);
                    }
                }
                return lstProducto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los productos: "+ex.Message);
            }            
        }

        public List<ProductosEntidad> FillProducto(string nombre)
        {
            List<ProductosEntidad> lstProducto = new List<ProductosEntidad>();

            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var productos = (from d in db.Productos
                                     where d.Nombre.Contains(nombre)
                                     select d).ToList();
                    foreach (var producto in productos)
                    {
                        ProductosEntidad oProducto = new ProductosEntidad();
                        oProducto.Id = producto.Id;
                        oProducto.Nombre = producto.Nombre;
                        oProducto.PrecioUnitario = producto.PrecioUnitario;
                        oProducto.Costo = producto.Costo;
                        lstProducto.Add(oProducto);
                    }
                }
                return lstProducto;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron listar los productos: " + ex.Message);
            }
        }

        public void AddProducto(ProductosEntidad oProducto)
        {
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Producto newProducto = new Producto();
                    newProducto.Nombre = oProducto.Nombre;
                    newProducto.PrecioUnitario = oProducto.PrecioUnitario;
                    newProducto.Costo = oProducto.Costo;
                    db.Productos.Add(newProducto);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto: " + ex.Message);
            }
        }

        public void UpdProducto(ProductosEntidad oProducto)
        {
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Producto newProducto = db.Productos.Find(oProducto.Id);
                    if (newProducto == null) throw new Exception("No se pudo encontrar el producto");
                    newProducto.Nombre = oProducto.Nombre;
                    newProducto.PrecioUnitario = oProducto.PrecioUnitario;
                    newProducto.Costo = oProducto.Costo;
                    db.Entry(newProducto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto: " + ex.Message);
            }
        }

        public void DelProducto(int id)
        {
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    Producto oProducto = db.Productos.Find(id);
                    if (oProducto == null) throw new Exception("No se pudo encontrar el producto");
                    db.Remove(oProducto);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto: " + ex.Message);
            }
        }

    }
}

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
    public class VentaService : IVentaService
    {
        public List<VentaEntidad> LstVenta()
        {
            List<VentaEntidad> lstVentas= new List<VentaEntidad>();
            try
            {
                using (VentasContext db = new VentasContext())
                {
                    var ventas = (from d in db.Ventas
                                  select d).ToList();
                    foreach (var venta in ventas)
                    {
                        VentaEntidad oVenta = new VentaEntidad();
                        oVenta.Id = venta.Id;
                        oVenta.IdCliente = venta.IdCliente;
                        oVenta.Total = venta.Total;
                        oVenta.Fecha = venta.Fecha;
                        using (VentasContext _db = new VentasContext())
                        {
                            var conceptos = (from d in _db.Conceptos
                                             where d.IdVenta == oVenta.Id
                                             select d).ToList();
                            foreach (var concepto in conceptos)
                            {
                                ConceptoEntidad oConcepto = new ConceptoEntidad();
                                oConcepto.Id = concepto.Id;
                                oConcepto.PrecioUnitario = concepto.PrecioUnitario;
                                oConcepto.Importe = concepto.Importe;
                                oConcepto.Cantidad = concepto.Cantidad;
                                oConcepto.IdProducto = concepto.IdProducto;
                                oConcepto.IdVenta = concepto.IdVenta;
                                oVenta.Conceptos.Add(oConcepto);
                            }
                        }
                        lstVentas.Add(oVenta);
                    }
                }
                return lstVentas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las ventas"+ex.Message);
            }
        }

        /// <summary>
        /// Metodo para agregar una venta, Depende de una interface
        /// </summary>
        /// <param name="oVenta">Objeto con los datos de la venta y los conceptos</param>
        /// <return>Si falla lanza una exepción</return>
        public void AddVenta(VentaEntidad oVenta)
        {
            using (VentasContext db = new VentasContext())
            {
                //transacción en caso de fallar, para hacer rollback a la base de datos
                using (var transaccion = db.Database.BeginTransaction())
                {
                    //este try hace que se devuelva todo si hay error (rollback)
                    try
                    {
                        Venta venta = new Venta();
                        venta.Total = oVenta.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);//hace la sumatoria de cada cantidad * precioUnitario
                        venta.Fecha = DateTime.Now;
                        venta.IdCliente = oVenta.IdCliente;
                        db.Ventas.Add(venta);
                        db.SaveChanges();

                        //carga los conceptos de la venta 
                        foreach (var concepto in oVenta.Conceptos)
                        {
                            var oConcepto = new Concepto();
                            oConcepto.Cantidad = concepto.Cantidad;
                            oConcepto.PrecioUnitario = concepto.PrecioUnitario;
                            oConcepto.Importe = concepto.Importe;
                            oConcepto.IdProducto = concepto.IdProducto;
                            oConcepto.IdVenta = venta.Id;
                            db.Conceptos.Add(oConcepto);
                            db.SaveChanges();
                        }

                        //para desbloquear las tablas
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Ocurrio un error en la inserción de los datos: "+ ex.Message);
                    }
                }
            }
        }
    }
}

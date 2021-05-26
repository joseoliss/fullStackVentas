using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.AccesoDatos.DB;
using Ventas.AccesoDatos.Services.Interfaces;
using Ventas.Entidades.Entidades;
using Ventas.Entidades.Models.Response;

namespace Ventas.AccesoDatos.AccessMethods
{
    public class VentaAcceso
    {
        #region CONSTRUCTOR
            private IVentaService _VentaService;
            public VentaAcceso(IVentaService ventaService)
            {
                _VentaService = ventaService;
            }
        #endregion

        #region MÉTODOS PÚBLICOS 
            /// <summary>
            /// Método para listar las ventas realizadas
            /// </summary>
            /// <returns>objeto respuesta: exito si _Exito == 1 y la lista de ventas, error _Exito == 0</returns>
            public Respuesta ListarVenta()
            {
                Respuesta oRespuesta = new Respuesta();
                oRespuesta._Exito = 0;
                try
                {
                    //inyecciòn de dependencias
                    var resultado = _VentaService.LstVenta();
                    oRespuesta._Exito = 1;
                    oRespuesta._Data = resultado;
                }
                catch (Exception ex)
                {
                    oRespuesta._Mensaje = ex.Message;
                }
                return oRespuesta;
            }

            /// <summary>
            /// Agrega una venta a la base de datos, recive la venta y los conceptos
            /// </summary>
            /// <param name="oVenta">entidad de tipo VentaEntidad</param>
            /// <returns>objeto respuesta: èxito si _Exito == 1, error _Exito == 0</returns>
            public Respuesta AgregarVenta(VentaEntidad oVenta)
            {
                Respuesta oRespuesta = new Respuesta();
                oRespuesta._Exito = 0;

                try
                {
                    //inyección de dependencias
                    _VentaService.AddVenta(oVenta);
                    oRespuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    oRespuesta._Mensaje = "Se produjo un error al guardar la venta: " + ex.Message;
                }

                return oRespuesta;
            }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.AccesoDatos.Services.Interfaces;
using Ventas.Entidades.Entidades;
using Ventas.Entidades.Models.Response;

namespace Ventas.AccesoDatos.AccessMethods
{
    public class ProductoAcceso
    {

        #region CONSTRUCTOR
            private IProductoService _productoService;
            public ProductoAcceso(IProductoService productoService)
            {
                _productoService = productoService;
            }
        #endregion

        #region MÉTODOS PÚBLICOS
            /// <summary>
            /// Lista los productos
            /// </summary>
            /// <returns>Retorna destro del objeto respuesta una lista de productos o un error</returns>
            public Respuesta ListarProducto()
            {
                Respuesta respuesta = new Respuesta();
                respuesta._Exito = 0;
                try
                {
                    //inyección de dependencias
                    var resultado = _productoService.LstProducto();
                    respuesta._Data = resultado;
                    respuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    respuesta._Mensaje = ex.Message;
                }

                return respuesta;
            }

            /// <summary>
            /// Filtra los productos según su nombre
            /// </summary>
            /// <param name="nombre">string que coincida con el nombre del producto</param>
            /// <returns></returns>
            public Respuesta FiltrarProducto(string nombre)
            {
                Respuesta respuesta = new Respuesta();
                respuesta._Exito = 0;
                try
                {
                    //inyección de dependencias
                    var resultado = _productoService.FillProducto(nombre);
                    respuesta._Data = resultado;
                    respuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    respuesta._Mensaje = ex.Message;
                }

                return respuesta;
            }

            /// <summary>
            /// Agrega un producto a la BD
            /// </summary>
            /// <param name="oProducto">Entidad de tipo producto</param>
            /// <returns>objeto respuesta: exito si _Exito == 1, error _Exito == 0</returns>
            public Respuesta AgregarProducto(ProductosEntidad oProducto)
            {
                Respuesta respuesta = new Respuesta();
                respuesta._Exito = 0;
                try
                {
                    //inyección de dependencias
                    _productoService.AddProducto(oProducto);
                    respuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    respuesta._Mensaje = ex.Message;
                }

                return respuesta;
            }

            /// <summary>
            /// Modifica un producto en la bd
            /// </summary>
            /// <param name="oProducto">Entidad de tipo producto</param>
            /// <returns>objeto respuesta: exito si _Exito == 1, error _Exito == 0</returns>
            public Respuesta ModificarProducto(ProductosEntidad oProducto)
            {
                Respuesta respuesta = new Respuesta();
                respuesta._Exito = 0;
                try
                {
                    //inyección de dependencias
                    _productoService.UpdProducto(oProducto);
                    respuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    respuesta._Mensaje = ex.Message;
                }

                return respuesta;
            }

            /// <summary>
            /// Elimina un productoi de la bd con su id
            /// </summary>
            /// <param name="id">int con el id del producto</param>
            /// <returns>objeto respuesta: exito si _Exito == 1, error _Exito == 0</returns>
            public Respuesta EliminarProducto(int id)
            {
                Respuesta respuesta = new Respuesta();
                respuesta._Exito = 0;
                try
                {
                    //inyección de dependencias
                    _productoService.DelProducto(id);
                    respuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    respuesta._Mensaje = ex.Message;
                }

                return respuesta;
            }
        #endregion
    }
}

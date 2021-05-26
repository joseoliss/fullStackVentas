using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.AccesoDatos.DB;
using Ventas.Entidades.Entidades;
using Ventas.AccesoDatos.Services.Interfaces;
using Ventas.Entidades.Models.Response;

namespace Ventas.AccesoDatos.AccessMethods
{
    public class ClienteAcceso
    {
        #region CONSTRUCTOR
            private IClienteService _clienteService;
            public ClienteAcceso(IClienteService clienteService)
            {
                _clienteService = clienteService;
            }
        #endregion

        #region METODOS PÚBLICOS
            /// <summary>
        /// Lista los clientes
        /// </summary>
        /// <returns>objeto respuesta: exito si _Exito == 1 y la lista de clientes, error _Exito == 0</returns>
            public Respuesta ListarCliente()
            {

                Respuesta oRespuesta = new Respuesta();
                oRespuesta._Exito = 0;
                try
                {
                    var resultado = _clienteService.LstClientes();
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
            /// Filtra un cliente de la base de datos
            /// </summary>
            /// <param name="nombre"></param>
            /// <returns>objeto respuesta: exito si _Exito == 1 y la lista de clientes filtrados, error _Exito == 0</returns>
            public Respuesta FiltrarCliente(string nombre)
            {
                Respuesta oRespuesta = new Respuesta();
                oRespuesta._Exito = 0;
                try
                {
                    var respuesta = _clienteService.FillClientes(nombre);
                    oRespuesta._Data = respuesta;
                    oRespuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    oRespuesta._Mensaje = ex.Message;
                }
                return oRespuesta;
            }

            /// <summary>
            /// Agrega un cliente a la bd
            /// </summary>
            /// <param name="oCliente">entidad de tipo Cliente</param>
            /// <returns>objeto respuesta: exito si _Exito == 1, error _Exito == 0</returns>
            public Respuesta AgregarCliente(ClienteEntidad oCliente)
            {
                Respuesta oRespuesta = new Respuesta();
                oRespuesta._Exito = 0;
                try
                {
                    _clienteService.AddCliente(oCliente);
                    oRespuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    oRespuesta._Mensaje = ex.Message;
                }
                return oRespuesta;
            }

            /// <summary>
            /// Modifica un cliente de la bd
            /// </summary>
            /// <param name="oCliente">entidad de tipo cliente </param>
            /// <returns>objeto respuesta: exito si _Exito == 1, error _Exito == 0</returns>
            public Respuesta ModificarCliente(ClienteEntidad oCliente)
            {
                Respuesta oRespuesta = new Respuesta();
                oRespuesta._Exito = 0;
                try
                {
                    _clienteService.UpdCliente(oCliente);
                    oRespuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    oRespuesta._Mensaje = ex.Message;
                }
                return oRespuesta;
            }

            /// <summary>
            /// elimina un cliente de la bd
            /// </summary>
            /// <param name="id">int con el id del cliente</param>
            /// <returns>objeto respuesta: exito si _Exito == 1, error _Exito == 0</returns>
            public Respuesta EliminarCliente(int id)
            {
                Respuesta oRespuesta = new Respuesta();
                oRespuesta._Exito = 0;
                try
                {
                    _clienteService.DelCliente(id);
                    oRespuesta._Exito = 1;
                }
                catch (Exception ex)
                {
                    oRespuesta._Mensaje = ex.Message;
                }
                return oRespuesta;
            }
        #endregion
    }
}

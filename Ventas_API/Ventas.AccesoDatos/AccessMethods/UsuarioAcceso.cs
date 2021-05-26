using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.AccesoDatos.Services.Interfaces;
using Ventas.Entidades.Entidades;
using Ventas.Entidades.Models.Request;
using Ventas.Entidades.Models.Response;

namespace Ventas.AccesoDatos.AccessMethods
{
    public class UsuarioAcceso
    {
        #region CONSTRUCTOR
            private IUsuarioService _IUsuarioService;
            public UsuarioAcceso(IUsuarioService iusuarioService)
            {
                _IUsuarioService = iusuarioService;
            }
        #endregion

        #region MÉTODOS PÚBLICOS
        /// <summary>
        /// Método para autenticar un usuario con JWT
        /// </summary>
        /// <param name="model">Recive correo y contraseña</param>
        /// <param name="secreto">Recive el secreto para generar el JWT</param>
        /// <returns>La respuesta de la solicitud correcta o incorrecta</returns>
        public Respuesta Login(AuthRequest model, string secreto)
        {
            Respuesta respuesta = new Respuesta();

            //va a la interfaz que se implementa en una clase
            //UsuarioService para verificar si el usuario existe
            //D de los 5 principios SOLID
            var userresponse = _IUsuarioService.Login(model, secreto);

            if (userresponse == null)
            {
                respuesta._Exito = 0;
                respuesta._Mensaje = "Usuario o contraseña incorrectos";
            }
            else
            {
                respuesta._Exito = 1;
                respuesta._Data = userresponse;
            }

            return respuesta;

        }

        /// <summary>
        /// Lista los usuarios de la bd
        /// </summary>
        /// <returns>obj respuesta: error si _Exito == 0, exito si _Exito == 1 con la lista de usuarios</returns>
        public Respuesta ListarUsuarios()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta._Exito = 0;
            try
            {
                var respuesta = _IUsuarioService.LstUsuario();
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
        /// Filtra un usuario de la bd
        /// </summary>
        /// <param name="nombre">string con el nombre a filtrar</param>
        /// <returns>obj respuesta: error si _Exito == 0, exito si _Exito == 1 con la lista de usuarios filtrados</returns>
        public Respuesta FiltrarUsuarios(string nombre)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta._Exito = 0;
            try
            {
                var respuesta = _IUsuarioService.FillUsuario(nombre);
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
        /// Agrega usuarios a la bd
        /// </summary>
        /// <param name="oUsuario">Entidad de tipo usuario</param>
        /// <returns>obj respuesta: error si _Exito == 0, exito si _Exito == 1</returns>
        public Respuesta AgregarUsuarios(UsuarioEntidad oUsuario)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta._Exito = 0;
            try
            {
                _IUsuarioService.AddUsuario(oUsuario);
                oRespuesta._Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta._Mensaje = ex.Message;
            }
            return oRespuesta;
        }

        /// <summary>
        /// Modifica un usuario de la bd
        /// </summary>
        /// <param name="oUsuario">Entidad de tipo usuario</param>
        /// <returns>obj respuesta: error si _Exito == 0, exito si _Exito == 1</returns>
        public Respuesta ModificarUsuarios(UsuarioEntidad oUsuario)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta._Exito = 0;
            try
            {
                _IUsuarioService.UpdUsuario(oUsuario);
                oRespuesta._Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta._Mensaje = ex.Message;
            }
            return oRespuesta;
        }

        /// <summary>
        /// Elimina un usuario de la base de datos
        /// </summary>
        /// <param name="id">int con el id del usuario</param>
        /// <returns>obj respuesta: error si _Exito == 0, exito si _Exito == 1</returns>
        public Respuesta EliminarUsuarios(int id)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta._Exito = 0;
            try
            {
                _IUsuarioService.DelUsuario(id);
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

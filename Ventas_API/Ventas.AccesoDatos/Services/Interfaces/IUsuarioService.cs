using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Entidades.Entidades;
using Ventas.Entidades.Models.Request;
using Ventas.Entidades.Models.Response;

namespace Ventas.AccesoDatos.Services.Interfaces
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Metodo implementado mediante una interfaz para la autenticación con JWT
        /// </summary>
        /// <param name="model">Modelo de los datos para hacer la verificación a la db (correo, contraseña)</param>
        /// <param name="secreto">Es una cadena de caracteres que viene desde el appSettings para el jwt entre mas largo y complicado, más seguro</param>
        /// <returns>Devuelve un AuthResponse, el correo y el token</returns>
        AuthResponse Login(AuthRequest model, string secreto);

        public List<UsuarioEntidad> LstUsuario();
        public List<UsuarioEntidad> FillUsuario(string nombre);
        public void AddUsuario(UsuarioEntidad oUsuario);
        public void UpdUsuario(UsuarioEntidad oUsuario);
        public void DelUsuario(int id);
    }
}

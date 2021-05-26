using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas.AccesoDatos.AccessMethods;
using Ventas.AccesoDatos.Services.Interfaces;
using Ventas.Entidades.Entidades;
using Ventas.Entidades.Models.Common;
using Ventas.Entidades.Models.Request;

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region CONSTRUCTOR
        //AppSettings trae el secreto para la autenticaciòn con jwt
        private IUsuarioService _IUsuarioService;
        private readonly AppSettings _appSettings;
        public UsuarioController(IUsuarioService iusuarioService, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _IUsuarioService = iusuarioService;
        }
        #endregion

        #region METODOS API
        /// <summary>
        /// Metodo para autenticar un usuario con JWT, para no acceder a las rutas sin autorización
        /// </summary>
        /// <param name="model">Recive el usuario y la contraseña</param>
        /// <returns>Si _Exito == 0 retorna 404 con un mensaje de error.
        /// si es 1 retorna la data con el token</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest model)
        {
            UsuarioAcceso oAcceso = new UsuarioAcceso(_IUsuarioService);
            var resultado = oAcceso.Login(model, _appSettings.Secreto);
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            UsuarioAcceso oUsuarie = new UsuarioAcceso(_IUsuarioService);
            var resultado = oUsuarie.ListarUsuarios();
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }

        [Authorize]
        [HttpPost("filtrar")]
        public IActionResult Fill(string nombre)
        {
            UsuarioAcceso oUsuarie = new UsuarioAcceso(_IUsuarioService);
            var resultado = oUsuarie.FiltrarUsuarios(nombre);
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(UsuarioEntidad oModel)
        {
            UsuarioAcceso oUsuarie = new UsuarioAcceso(_IUsuarioService);
            var resultado = oUsuarie.AgregarUsuarios(oModel);
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Upd(UsuarioEntidad oModel)
        {
            UsuarioAcceso oUsuarie = new UsuarioAcceso(_IUsuarioService);
            var resultado = oUsuarie.ModificarUsuarios(oModel);
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            UsuarioAcceso oUsuarie = new UsuarioAcceso(_IUsuarioService);
            var resultado = oUsuarie.EliminarUsuarios(id);
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }
        #endregion
    }
}

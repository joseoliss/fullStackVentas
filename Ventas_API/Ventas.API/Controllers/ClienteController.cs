using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas.AccesoDatos.AccessMethods;
using Ventas.AccesoDatos.Services.Interfaces;
using Ventas.Entidades.Entidades;

namespace Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        #region CONSTRUCTOR
        private IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        #endregion

        #region METODOS API
        [HttpGet]
        public IActionResult Get()
        {
            ClienteAcceso oClienteAcceso = new ClienteAcceso(_clienteService);
            var respuesta = oClienteAcceso.ListarCliente();
            if (respuesta._Exito == 0) return BadRequest(respuesta);
            return Ok(respuesta);
        }

        [HttpPost("filtrar")]
        public IActionResult Fill(string nombre)
        {
            ClienteAcceso oClienteAcceso = new ClienteAcceso(_clienteService);
            var respuesta = oClienteAcceso.FiltrarCliente(nombre);
            if (respuesta._Exito == 0) return BadRequest(respuesta);
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Post(ClienteEntidad oModel)
        {
            ClienteAcceso oClienteAcceso = new ClienteAcceso(_clienteService);
            var respuesta = oClienteAcceso.AgregarCliente(oModel);
            if (respuesta._Exito == 0) return BadRequest(respuesta);
            return Ok(respuesta);
        }

        [HttpPut]
        public IActionResult Put(ClienteEntidad oModel)
        {
            ClienteAcceso oClienteAcceso = new ClienteAcceso(_clienteService);
            var respuesta = oClienteAcceso.ModificarCliente(oModel);
            if (respuesta._Exito == 0) return BadRequest(respuesta);
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ClienteAcceso oClienteAcceso = new ClienteAcceso(_clienteService);
            var respuesta = oClienteAcceso.EliminarCliente(id);
            if (respuesta._Exito == 0) return BadRequest(respuesta);
            return Ok(respuesta);
        }
        #endregion
    }
}

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
    public class VentaController : ControllerBase
    {
        #region CONSTRUCTOR
        private IVentaService _VentaService;
        public VentaController(IVentaService ventaService)
        {
            _VentaService = ventaService;
        }
        #endregion

        #region MÉTODOS DEL API
        [HttpGet]
        public IActionResult Lst()
        {
            VentaAcceso oVentaAcceso = new VentaAcceso(_VentaService);
            var respuesta = oVentaAcceso.ListarVenta();
            if (respuesta._Exito == 0) return BadRequest(respuesta);
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Add(VentaEntidad oVentaEntidad)
        {
            VentaAcceso oVentaAcceso = new VentaAcceso(_VentaService);
            var respuesta = oVentaAcceso.AgregarVenta(oVentaEntidad);
            if (respuesta._Exito == 0) return BadRequest(respuesta);
            return Ok(respuesta);
        }
        #endregion

    }
}

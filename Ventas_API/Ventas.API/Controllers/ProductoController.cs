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
    public class ProductoController : ControllerBase
    {
        #region CONSTRUCTOR
        private IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        #endregion

        #region MÉTODOS DEL API
        [HttpGet]
        public IActionResult Get()
        {
            ProductoAcceso oProducto = new ProductoAcceso(_productoService);
            var resultado = oProducto.ListarProducto();
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpPost("filtrar")]
        public IActionResult List(string nombre)
        {
            ProductoAcceso oProducto = new ProductoAcceso(_productoService);
            var resultado = oProducto.FiltrarProducto(nombre);
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpPost]
        public IActionResult Add(ProductosEntidad oEntidad)
        {
            ProductoAcceso oProducto = new ProductoAcceso(_productoService);
            var resultado = oProducto.AgregarProducto(oEntidad);
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Upd(ProductosEntidad oEntidad)
        {
            ProductoAcceso oProducto = new ProductoAcceso(_productoService);
            var resultado = oProducto.ModificarProducto(oEntidad);
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            ProductoAcceso oProducto = new ProductoAcceso(_productoService);
            var resultado = oProducto.EliminarProducto(id);
            if (resultado._Exito == 0) return BadRequest(resultado);
            return Ok(resultado);
        }
        #endregion
    }
}

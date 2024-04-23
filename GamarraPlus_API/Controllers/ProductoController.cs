using GamarraPlus.Models;
using GamarraPlus_API.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamarraPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerProductos()
        {
            var lista = await Task.Run(() => new ProductoDAO().obtenerProductos());
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> registrarProducto(Producto reg)
        {
            var mensaje = await Task.Run(() => new ProductoDAO().registrarProducto(reg));
            return Ok(mensaje);
        }

        [HttpPut]
        public async Task<IActionResult> actualizarProducto(Producto reg)
        {
            var mensaje = await Task.Run(() => new ProductoDAO().actualizarProducto(reg));
            return Ok(mensaje);
        }
    }
}

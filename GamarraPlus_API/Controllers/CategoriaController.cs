using GamarraPlus_API.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamarraPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerCategorias()
        {
            var lista = await Task.Run(() => new CategoriaDAO().obtenerCategorias());
            return Ok(lista);
        }
    }
}

using GamarraPlus_API.Repositorio.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamarraPlus_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> obtenerMarcas()
        {
            var lista = await Task.Run(() => new MarcaDAO().obtenerMarcas());
            return Ok(lista);   
        }

    }
}

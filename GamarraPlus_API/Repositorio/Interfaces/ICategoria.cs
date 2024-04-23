using GamarraPlus.Models;

namespace GamarraPlus_API.Repositorio.Interfaces
{
    public interface ICategoria
    {
        IEnumerable<Categoria> obtenerCategorias();

    }
}

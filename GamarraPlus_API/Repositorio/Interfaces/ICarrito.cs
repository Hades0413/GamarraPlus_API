using GamarraPlus.Models;

namespace GamarraPlus_API.Repositorio.Interfaces
{
    public interface ICarrito
    {
        IEnumerable<Carrito> obtenerCarritos();
    }
}

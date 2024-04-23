using GamarraPlus.Models;

namespace GamarraPlus_API.Repositorio.Interfaces
{
    public interface ICompra
    {
        IEnumerable<Compra> obtenerCompras();
    }
}

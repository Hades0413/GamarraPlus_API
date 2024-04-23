using GamarraPlus.Models;

namespace GamarraPlus_API.Repositorio.Interfaces
{
    public interface IDetalleCompra
    {
        IEnumerable<DetalleCompra> obtenerDetalleCompras();
    }
}

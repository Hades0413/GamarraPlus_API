using GamarraPlus.Models;

namespace GamarraPlus_API.Repositorio.Interfaces
{
    public interface IProducto
    {
        IEnumerable<Producto> obtenerProductos();

        //Producto obtenerProductoPorId(string id);
        string registrarProducto(Producto reg);
        string actualizarProducto(Producto reg);
        //string eliminarProducto(Producto reg);

    }
}

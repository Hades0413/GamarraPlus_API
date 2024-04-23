using GamarraPlus.Models;

namespace GamarraPlus_API.Repositorio.Interfaces
{
    public interface IUsuario
    {
        IEnumerable<Usuario> obtenerUsuarios();
    }
}

using GamarraPlus.Models;

namespace GamarraPlus_API.Repositorio.Interfaces
{
    public interface IDepartamento
    {
        IEnumerable<Departamento> obtenerDepartamentos();
    }
}

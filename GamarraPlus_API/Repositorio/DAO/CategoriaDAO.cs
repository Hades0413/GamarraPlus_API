using GamarraPlus.Models;
using GamarraPlus_API.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GamarraPlus_API.Repositorio.DAO
{
    public class CategoriaDAO : ICategoria
    {

        private readonly string cadena;

        public CategoriaDAO() {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public IEnumerable<Categoria> obtenerCategorias()
        {
            List<Categoria> lstCategorias = new List<Categoria>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("sp_obtenerCategoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Categoria reg = new Categoria();
                reg.IdCategoria = dr.GetInt32("IdCategoria");
                reg.Descripcion = dr.GetString("Descripcion");
                reg.Activo = dr.GetBoolean("Activo");
                lstCategorias.Add(reg);
            }

            dr.Close();
            cn.Close();
            return lstCategorias;
        }
    }
}

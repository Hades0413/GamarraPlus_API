using GamarraPlus.Models;
using GamarraPlus_API.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GamarraPlus_API.Repositorio.DAO
{
    public class MarcaDAO : IMarca
    {

        private readonly string cadena;

        public MarcaDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }


        public IEnumerable<Marca> obtenerMarcas()
        {
            List<Marca> lstMarcas = new List<Marca>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("sp_obtenerMarca", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Marca reg = new Marca();
                reg.IdMarca = dr.GetInt32("IdMarca");
                reg.Descripcion = dr.GetString("Descripcion");
                reg.Activo = dr.GetBoolean("Activo");
                lstMarcas.Add(reg);
            }
            dr.Close();
            cn.Close();
            return lstMarcas;

        }
    }
}

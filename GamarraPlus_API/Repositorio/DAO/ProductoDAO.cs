using System.Data;
using GamarraPlus.Models;
using GamarraPlus_API.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace GamarraPlus_API.Repositorio.DAO
{
    public class ProductoDAO : IProducto
    {
        private readonly string cadena;

        public ProductoDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }

        public string actualizarProducto(Producto reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            string mensaje = "";

            try
            {
                SqlCommand cmd = new SqlCommand("sp_editarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("@IdProducto", reg.IdProducto);
                cmd.Parameters.AddWithValue("@Nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", reg.Descripcion);
                cmd.Parameters.AddWithValue("@IdMarca", reg.oMarca);
                cmd.Parameters.AddWithValue("@IdCategoria", reg.oCategoria);
                cmd.Parameters.AddWithValue("@Precio", reg.Precio);
                cmd.Parameters.AddWithValue("@Stock", reg.Stock);
                cmd.Parameters.AddWithValue("@Activo", reg.Activo);

                // Parámetro de salida
                SqlParameter resultado = new SqlParameter("@Resultado", SqlDbType.Bit);
                resultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(resultado);

                cn.Open();
                cmd.ExecuteNonQuery();

                bool resultadoValor = (bool)resultado.Value;
                if (resultadoValor)
                {
                    mensaje = "Actualización exitosa.";
                }
                else
                {
                    mensaje = "No se pudo actualizar el producto.";
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar el producto: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

        /*
        public string eliminarProducto(Producto id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";
            cn.Open() ;
            try
            {
                SqlCommand cmd = new SqlCommand("", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdProducto", id);
            }
        }

        public Producto obtenerProductoPorId(string id)
        {
            throw new NotImplementedException();
        }

                /*
        public Producto obtenerProductoPorId(string id)
        {
           var producto = obtenerProductos().Where(p => p.IdProducto == id).FirstOrDefault();
           if (producto == null)        
               return new Producto();          
           else       
               return producto;

        }*/

        public IEnumerable<Producto> obtenerProductos()
        {
            List<Producto> lstProductos = new List<Producto>();
            SqlConnection cn = new SqlConnection(cadena);

            SqlCommand cmd = new SqlCommand("sp_obtenerProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Producto reg = new Producto();
                reg.IdProducto = dr.GetInt32("IdProducto");
                reg.Nombre = dr.GetString("Nombre");
                reg.Descripcion = dr.GetString("Descripcion");
                reg.Precio = dr.GetDecimal("Precio");
                reg.Stock = dr.GetInt32("Stock");
                reg.RutaImagen = dr.GetString("RutaImagen");
                reg.Activo = dr.GetBoolean("Activo");

                Marca marca = new Marca();
                marca.IdMarca = dr.GetInt32("IdMarca");
                marca.Descripcion = dr.GetString("DescripcionMarca");
                reg.oMarca = marca;

                Categoria cat = new Categoria();
                cat.IdCategoria = dr.GetInt32("IdCategoria");
                cat.Descripcion = dr.GetString("DescripcionCategoria");
                reg.oCategoria = cat;
                lstProductos.Add(reg);

            }

            dr.Close();
            cn.Close();
            return lstProductos;
        }

        public string registrarProducto(Producto reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            string mensaje = "";

            try
            {
                SqlCommand cmd = new SqlCommand("sp_registrarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros de entrada
                cmd.Parameters.AddWithValue("@Nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", reg.Descripcion);
                cmd.Parameters.AddWithValue("@IdMarca", reg.oMarca);
                cmd.Parameters.AddWithValue("@IdCategoria", reg.oCategoria);
                cmd.Parameters.AddWithValue("@Precio", reg.Precio);
                cmd.Parameters.AddWithValue("@Stock", reg.Stock);
                cmd.Parameters.AddWithValue("@RutaImagen", reg.RutaImagen);

                // Parámetro de salida
                SqlParameter resultado = new SqlParameter("@Resultado", SqlDbType.Int);
                resultado.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(resultado);

                cn.Open();
                cmd.ExecuteNonQuery();

                int resultadoValor = Convert.ToInt32(resultado.Value);
                if (resultadoValor > 0)
                {
                    mensaje = "Producto registrado con éxito. ID del nuevo producto: " + resultadoValor;
                }
                else
                {
                    mensaje = "No se pudo registrar el producto.";
                }
            }
            catch (SqlException ex)
            {
                mensaje = "Error al registrar el producto: " + ex.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

    }
}

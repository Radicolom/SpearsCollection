using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClProductoD
    {
        private ClConexion conexion = new ClConexion();
        public int MtdGuardar (ClProductoE producto, out string strError)
        {
            strError = string.Empty;
            int result = 0;

            try
            {
                using (SqlConnection conex = conexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarProducto", conex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigoProducto", producto.codigoProducto);
                    cmd.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("@descripcionProducto", producto.descripcionProducto);
                    cmd.Parameters.AddWithValue("@imagenProducto", producto.imagenProducto);
                    cmd.Parameters.AddWithValue("@nombreMaterial", producto.objMaterial.nombreMaterial);
                    cmd.Parameters.AddWithValue("@idCategoria", producto.idCategoria);

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception exp)
            {
                strError = exp.ToString();
                throw;
            }
            finally
            {
                conexion.MtdCerrarConex();
            }

            return result;
        }
    }
}

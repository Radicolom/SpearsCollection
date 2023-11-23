using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClCompraD
    {
        private ClConexion objConexion = new ClConexion();

        public List<ClDetalleCompraE> Mtdlistar(out string mensaje)
        {
            mensaje = string.Empty;
            List<ClDetalleCompraE> lista = null;
            try
            {
                using (SqlConnection conex = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarInsumosCompra", conex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClDetalleCompraE = new ClDetalleCompraE()
                            {

                            }
                        }
                    }

                }
            }
            catch (Exception exp)
            {
                mensaje = exp.ToString();
                throw;
            }
            finally
            {
                objConexion.MtdCerrarConex();
            }

            return lista;
        }



    }
}

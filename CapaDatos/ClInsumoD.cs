using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClInsumoD
    {
        private ClConexion objConexion = new ClConexion();

        public List<ClInsumoE> MtdListar(out string mensaje)
        {
            mensaje = string.Empty;
            List<ClInsumoE> lista = new List<ClInsumoE>();
            try
            {
                using (SqlConnection conex = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarInsumos", conex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            ClInsumoE insumo = new ClInsumoE()
                            {
                                idInsumo = Convert.ToInt32(reader["idInsumo"]),
                                nombreInsumo = reader["nombreInsumo"].ToString(),
                                cantidadInsumo = Convert.ToInt32(reader["cantidadInsumo"]),
                                imagenInsumo = reader["imagenInsumo"].ToString(),
                                descripcionInsumo = reader["descripcionInsumo"].ToString(),
                            };

                            insumo.objMaterial = new ClMaterialE()
                            {
                                idMaterial = Convert.ToInt32(reader["idMaterial"]),
                                nombreMaterial = reader["nombreMaterial"].ToString(),
                                descripcionMaterial = reader["descripcionMaterial"].ToString()
                            };

                            lista.Add(insumo);
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
    
        public int MtdGuardar(ClInsumoE objInsumo, out string mensaje)
        {
            mensaje = string.Empty;
            int resultado = 0;

            try
            {
                using (SqlConnection conex = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("", conex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("", objInsumo.nombreInsumo);
                    cmd.Parameters.AddWithValue("", objInsumo.cantidadInsumo);
                    cmd.Parameters.AddWithValue("", objInsumo.descripcionInsumo);
                    cmd.Parameters.AddWithValue("", objInsumo.objMaterial.idMaterial);

                    resultado = cmd.ExecuteNonQuery();
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

            return resultado;
        }



    }
}

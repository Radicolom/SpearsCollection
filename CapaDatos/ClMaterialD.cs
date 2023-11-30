using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClMaterialD
    {
        private ClConexion objConexion = new ClConexion();


        public List<ClMaterialE> MtdListar(out string mensaje)
        {
            mensaje = string.Empty;
            List<ClMaterialE> lista = new List<ClMaterialE>();

            try
            {
                using (SqlConnection conex = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_Listar", conex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tablaSelecionada", "material");

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClMaterialE materialDato = new ClMaterialE()
                            {
                                idMaterial = Convert.ToInt32(reader["idMaterial"]),
                                nombreMaterial = reader["nombreMaterial"].ToString(),
                                descripcionMaterial = reader["descripcionMaterial"].ToString()
                            };

                            lista.Add(materialDato);
                        }
                    }

                }
            }
            catch (Exception exp)
            {
                mensaje = exp.ToString();

                throw;
            }finally
            {
                objConexion.MtdCerrarConex();
            }
            return lista;
        }

        public int MtdGuardar(ClMaterialE material, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;
            try
            {
                using (SqlConnection conex = objConexion.MtdAbrirConex())
                {

                    SqlCommand cmd = new SqlCommand("SP_GuardarMatrial", conex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombreMaterial", material.nombreMaterial);
                    cmd.Parameters.AddWithValue("@descripcionMaterial", material.descripcionMaterial);

                    result = cmd.ExecuteNonQuery();

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
            return result;
        }


    }
}

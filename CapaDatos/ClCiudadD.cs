using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClCiudadD
    {
        private ClConexion objConexion = new ClConexion();
        public List<ClCiudadE> MtdListar(out string mensaje)
        {
            mensaje = string.Empty;
            List<ClCiudadE> lista = new List<ClCiudadE>();
            try
            {
                using (SqlConnection conex = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("sp_Listar", conex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tablaSelecionada", "ciudad");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ClCiudadE()
                            {
                                idCiudad = Convert.ToInt32(reader["idCiudad"]),
                                nombreCiudad = reader["nombreCiudad"].ToString()
                            });
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

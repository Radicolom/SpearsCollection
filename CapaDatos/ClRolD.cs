using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClRolD
    {
        public List<ClRolE> MtdListar()
        {
            ClConexion objConexion = new ClConexion();
            List<ClRolE> lista = new List<ClRolE>();

            try
            {
                using (SqlConnection conexion = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tablaSelecionada", "rol");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ClRolE()
                            {
                                idRol = Convert.ToInt32(reader["idRol"]),
                                nombreRol = reader["nombre"].ToString()
                            }    
                            );
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            objConexion.MtdCerrarConex();

            return lista;
        }
    }
}

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
        private ClConexion objConexion = new ClConexion();
        public List<ClRolE> MtdListar(out string mensaje)
        {
            mensaje = string.Empty;
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
                                nombreRol = reader["nombreRol"].ToString()
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

        public int MtdGuardar(ClRolE objRol, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;
            try
            {
                using (SqlConnection conexion = objConexion.MtdAbrirConex())
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarTabla", conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombreDato", objRol.nombreRol);
                    cmd.Parameters.AddWithValue("@tablaSeleccionada", "rol");

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

        public int MtdEliminar(ClRolE objRol, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;
            try
            {
                using (SqlConnection conexion = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarDato", conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tablaSeleccionada", "rol");
                    cmd.Parameters.AddWithValue("@idDato", objRol.idRol);

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

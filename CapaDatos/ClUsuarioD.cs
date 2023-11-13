using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class ClUsuarioD
    {
        private ClConexion objConexion = new ClConexion();

        public List<ClUsuarioE> MtdListar(out string mensaje)
        {
            mensaje = string.Empty;
            List<ClUsuarioE> lista = new List<ClUsuarioE>();

            try
            {
                using (SqlConnection conexion = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_ListarUsuario", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClUsuarioE usuario = new ClUsuarioE()
                            {
                                idUsuario = Convert.ToInt32(reader["idUsuario"]),
                                documentoUsuario = reader["documentoUsuario"].ToString(),
                                nombreUsuario = reader["nombreUsuario"].ToString(),
                                apellidoUsuario = reader["apellidoUsuario"].ToString(),
                                tellUsuario = reader["tellUsuario"].ToString(),
                                correoUsuario = reader["correoUsuario"].ToString(),
                                claveUsuario = reader["claveUsuario"].ToString(),
                                direccionUsuario = reader["direccionUsuario"].ToString(),
                                estadoUsuario = Convert.ToBoolean(reader["estadoUsuario"]),
                                fechaUsuario = reader["fechaUsuario"].ToString()
                            };

                            // Acceder a las dependencias
                            usuario.objRol = new ClRolE
                            {
                                idRol = Convert.ToInt32(reader["idRol"]),
                                nombreRol = reader["nombreRol"].ToString()
                            };

                            usuario.objCiudad = new ClCiudadE
                            {
                                idCiudad = Convert.ToInt32(reader["idCiudad"]),
                                nombreCiudad = reader["nombreCiudad"].ToString()
                            };

                            usuario.objCiudad.objDepartamento = new ClDepartamentoE
                            {
                                idDepartamento = Convert.ToInt32(reader["idDepartamento"]),
                                nombreDepartamento = reader["nombreDepartamento"].ToString()
                            };

                            lista.Add(usuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            finally
            {
                objConexion.MtdCerrarConex();
            }

            return lista;
        }

        public int MtdGuardar(ClUsuarioE objUsuarioE, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;

            try
            {
                using (SqlConnection conexion = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarUsuario", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@documentoUsuario", objUsuarioE.documentoUsuario);
                    cmd.Parameters.AddWithValue("@nombreUsuario", objUsuarioE.nombreUsuario);
                    cmd.Parameters.AddWithValue("@apellidoUsuario", objUsuarioE.apellidoUsuario);
                    cmd.Parameters.AddWithValue("@telUsuario", objUsuarioE.tellUsuario);
                    cmd.Parameters.AddWithValue("@correoUsuario", objUsuarioE.correoUsuario);
                    cmd.Parameters.AddWithValue("@claveUsuario", objUsuarioE.claveUsuario);
                    cmd.Parameters.AddWithValue("@direccionUsuario", objUsuarioE.direccionUsuario);
                    cmd.Parameters.AddWithValue("@estadoUsuario", objUsuarioE.estadoUsuario);
                    cmd.Parameters.AddWithValue("@ciudadUsuario", objUsuarioE.objCiudad.idCiudad);
                    cmd.Parameters.AddWithValue("@idRol", objUsuarioE.objRol.idRol);

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

        public int MtdActualizar(ClUsuarioE objUsuarioE, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;

            try
            {
                using (SqlConnection conexion = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_ActualizarUsuario", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@documentoUsuario", objUsuarioE.documentoUsuario);
                    cmd.Parameters.AddWithValue("@nombreUsuario", objUsuarioE.nombreUsuario);
                    cmd.Parameters.AddWithValue("@apellidoUsuario", objUsuarioE.apellidoUsuario);
                    cmd.Parameters.AddWithValue("@telUsuario", objUsuarioE.tellUsuario);
                    cmd.Parameters.AddWithValue("@correoUsuario", objUsuarioE.correoUsuario);
                    cmd.Parameters.AddWithValue("@direccionUsuario", objUsuarioE.direccionUsuario);
                    cmd.Parameters.AddWithValue("@estadoUsuario", objUsuarioE.estadoUsuario);
                    cmd.Parameters.AddWithValue("@ciudadUsuario", objUsuarioE.objCiudad.idCiudad);
                    cmd.Parameters.AddWithValue("@idRol", objUsuarioE.objRol.idRol);
                    cmd.Parameters.AddWithValue("@idUsuario", objUsuarioE.idUsuario);

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

        public int MtdEliminar(ClUsuarioE objUsuarioE, out string mensaje)
        {
            int result = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection conexion = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarDato", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tablaSeleccionada", "usuario");
                    cmd.Parameters.AddWithValue("@idDato", objUsuarioE.idUsuario);

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

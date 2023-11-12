using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using static CapaEntidad.ClDatos;

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
                                documentoUsuario = reader["documento"].ToString(),
                                nombreUsuario = reader["nombre"].ToString(),
                                apellidoUsuario = reader["apellido"].ToString(),
                                tellUsuario = reader["tell"].ToString(),
                                correoUsuario = reader["correo"].ToString(),
                                claveUsuario = reader["clave"].ToString(),
                                direccionUsuario = reader["direccion"].ToString(),
                                estadoUsuario = Convert.ToBoolean(reader["estado"]),
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
    }


    public int MtdGuardar(ClUsuarioE objUsuarioE)
        {
            int result = 0;

            try
            {
                using (SqlConnection conexion = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = null;
                    if (objUsuarioE.idUsuario == -1)
                    {
                        cmd = new SqlCommand("SP_RegistrarUsuario", conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@documento", objUsuarioE.documentoUsuario);
                        cmd.Parameters.AddWithValue("@apellido", objUsuarioE.apellidoUsuario);
                        cmd.Parameters.AddWithValue("@correo", objUsuarioE.correoUsuario);
                        cmd.Parameters.AddWithValue("@clave", objUsuarioE.claveUsuario);
                        cmd.Parameters.AddWithValue("@estado", objUsuarioE.estadoUsuario);
                        cmd.Parameters.AddWithValue("@idRol", objUsuarioE.idRol);
                        cmd.Parameters.AddWithValue("@nombre", objUsuarioE.nombreUsuario);
                    }
                    else
                    {
                        cmd = new SqlCommand("SP_GuardarUsuario", conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@documento", objUsuarioE.documentoUsuario);
                        cmd.Parameters.AddWithValue("@apellido", objUsuarioE.apellidoUsuario);
                        cmd.Parameters.AddWithValue("@correo", objUsuarioE.correoUsuario);
                        cmd.Parameters.AddWithValue("@estado", objUsuarioE.estadoUsuario);
                        cmd.Parameters.AddWithValue("@idRol", objUsuarioE.idRol);
                        cmd.Parameters.AddWithValue("@idUsuario", objUsuarioE.idUsuario);
                        cmd.Parameters.AddWithValue("@nombre", objUsuarioE.nombreUsuario);
                    }

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }

            objConexion.MtdCerrarConex();

            return result;
        }

        public int MtdEliminar(ClUsuarioE objUsuarioE)
        {
            int result = 0;
            try
            {
                using (SqlConnection conexion = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarUsuario", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", objUsuarioE.idUsuario);

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }

            objConexion.MtdCerrarConex();

            return result;
        }

    }
}

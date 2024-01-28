using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

							// Cargar la imagen desde la ruta almacenada
							if (!string.IsNullOrEmpty(insumo.imagenInsumo))
							{
								// Obtener la ruta física completa de la imagen
								string rutaCompletaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..", insumo.imagenInsumo);

								// Verificar si el archivo existe
								if (File.Exists(rutaCompletaImagen))
								{
									// Leer la imagen como un arreglo de bytes y asignarla al objeto insumo
									byte[] imagenBytes = File.ReadAllBytes(rutaCompletaImagen);
									insumo.imagenBytes = imagenBytes; // Puedes agregar un atributo imagenBytes en tu clase ClInsumoE
								}
							}

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
    
        public int MtdGuardar(ClDetalleCompraE objInsumo, out string mensaje)
        {
            mensaje = string.Empty;
            int resultado = 0;

            try
            {
                using (SqlConnection conex = objConexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarCompraInsumo", conex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cantidadCompra", objInsumo.cantidadCompra);
                    cmd.Parameters.AddWithValue("@precioCompra", objInsumo.precioCompra);
                    cmd.Parameters.AddWithValue("@numeroCompra", objInsumo.objCompra.numeroCompra);
                    cmd.Parameters.AddWithValue("@estadoCompra", objInsumo.objCompra.estadoCompra);
                    cmd.Parameters.AddWithValue("@idProveedor", objInsumo.objCompra.objProveedor.idUsuario);
                    cmd.Parameters.AddWithValue("@nombreInsumo", objInsumo.objInsumo.nombreInsumo);
                    cmd.Parameters.AddWithValue("@descripcionInsumo", objInsumo.objInsumo.descripcionInsumo);
                    cmd.Parameters.AddWithValue("@nombreMaterial", objInsumo.objInsumo.objMaterial.nombreMaterial);
                    cmd.Parameters.AddWithValue("@descripcionMaterial", objInsumo.objInsumo.objMaterial.descripcionMaterial);
                    cmd.Parameters.AddWithValue("@imagenInsumo", objInsumo.objInsumo.imagenInsumo);

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

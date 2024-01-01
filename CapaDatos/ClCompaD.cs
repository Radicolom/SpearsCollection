using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClCompaD
    {
        private ClConexion objConexion = new ClConexion();

        public List<ClDetalleCompraE> Mtdlistar(out string mensaje)
        {
            mensaje = string.Empty;
            List<ClDetalleCompraE> lista = new List<ClDetalleCompraE>();

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
                            ClDetalleCompraE compra = new ClDetalleCompraE()
                            {
                                idDetalleCompra = Convert.ToInt32(reader["idDetalleCompra"]),
                                cantidadCompra = Convert.ToInt32(reader["cantidadCompra"]),
                                precioCompra = Convert.ToDecimal(reader["precioCompra"])
                            };

                            compra.objInsumo = new ClInsumoE()
                            {
                                idInsumo = Convert.ToInt32(reader["idInsumo"]),
                                nombreInsumo = reader["nombreInsumo"].ToString(),
                                cantidadInsumo = Convert.ToInt32(reader["cantidadInsumo"]),
                                descripcionInsumo = reader["descripcionInsumo"].ToString()
                            };

                            compra.objInsumo.objMaterial = new ClMaterialE()
                            {
                                idMaterial = Convert.ToInt32(reader["idMaterial"]),
                                nombreMaterial = reader["nombreMaterial"].ToString(),
                                descripcionMaterial = reader["descripcionMaterial"].ToString()
                            };

                            compra.objCompra = new ClCompraE()
                            {
                                idCompra = Convert.ToInt32(reader["idCompra"]),
                                numeroCompra = reader["numeroCompra"].ToString(),
                                estadoCompra = Convert.ToBoolean(reader["estadoCompra"]),
                                fechaCompra = reader["fechaCompra"].ToString(),
                                imagenCompra = reader["imagenCompra"].ToString()
                            };

                            compra.objCompra.objProveedor = new ClUsuarioE()
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

                            lista.Add(compra);

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

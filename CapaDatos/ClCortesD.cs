using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClCortesD
    {
        //Instancia ClConexion
        private ClConexion objConnexion = new ClConexion();

        public List<ClCorteE> MtdLista(out string mensaje)
        {
            mensaje= string.Empty;
            List<ClCorteE> lista = new List<ClCorteE>();
            
            try
            {
                using (SqlConnection conex = objConnexion.MtdAbrirConex())
                {
                    SqlCommand cmd = new SqlCommand("", conex);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter());

                    using (SqlDataReader reder = cmd.ExecuteReader())
                    {
                        while (reder.Read())
                        {
                            ClCorteE list = new ClCorteE()
                            {
                                idCorte = Convert.ToInt32(reder[""]),
                                nombrePrendaCorte = reder[""].ToString(),
                                numeroPiezasCorte = Convert.ToInt32(reder[""])
                            };

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
                objConnexion.MtdCerrarConex();
            }
            return lista;
        }

    }
}

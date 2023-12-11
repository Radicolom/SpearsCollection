using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace capaEmpresa.Models
{
    public class ClCompraL
    {
        private string emailY = "speearscollectionbbc@gmail.com";
        private ClCompaD objCompra = new ClCompaD();
        public List<ClDetalleCompraE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClDetalleCompraE> lista = objCompra.Mtdlistar(out mensaje);
            //List<ClDetalleCompraE> listaCompra = new List<ClDetalleCompraE>();
            //foreach (ClDetalleCompraE columna in lista)
            //{
            //    if (columna.objCompra.idCompra != null || columna.objCompra.idCompra > 0)
            //    {
            //        listaCompra.Add(columna);
            //    }
            //}
            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(emailY, mensaje);
            }

            return lista;
        }
    }
}
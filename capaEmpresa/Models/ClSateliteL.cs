using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace capaEmpresa.Models
{
    public class ClSateliteL
    {
        private string emailY = "speearscollectionbbc@gmail.com";
        private ClUsuarioD objUsuario = new ClUsuarioD();

        public List<ClUsuarioE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClUsuarioE> lista = objUsuario.MtdListar(out mensaje);
            List<ClUsuarioE> listaSatelite = new List<ClUsuarioE>();

            foreach (ClUsuarioE columna in lista)
            {
                if (string.Equals(columna.objRol.nombreRol, "Satelite", StringComparison.OrdinalIgnoreCase))
                {
                    listaSatelite.Add(columna);
                }
            }
            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(emailY, mensaje);
            }

            return listaSatelite;

        }





    }
}
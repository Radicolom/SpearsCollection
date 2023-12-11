using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace capaEmpresa.Models
{
    public class ClCiudadL
    {
        private ClCiudadD objCiudad = new ClCiudadD();
        public List<ClCiudadE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClCiudadE> lista = new List<ClCiudadE>();

            lista = objCiudad.MtdListar(out mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail("", "Error " + mensaje);
            }

            return lista;

        }
    }
}

using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ClInsumoL
    {
        private ClInsumoD objInsumo = new ClInsumoD();
        private string emailY = "";

        public List<ClInsumoE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClInsumoE> lista = objInsumo.MtdListar(out mensaje);
            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(emailY, mensaje);
            }
            
            return lista;
        }

    }
}

using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ClMaterialL
    {
        private ClMaterialD objMaterial = new ClMaterialD();
        private string correo = "";

        public List<ClMaterialE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClMaterialE> lista = objMaterial.MtdListar(out mensaje);
            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(correo, mensaje);
            }
            return lista;
        }


        public int MtdGuardar(ClMaterialE material, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;
            if (string.IsNullOrEmpty(material.nombreMaterial))
            {
                mensaje = "El nombre del material no puede ser vacio";
            }
            else
            {
                result = objMaterial.MtdGuardar(material, out mensaje);
                
                if (!string.IsNullOrEmpty(mensaje))
                {
                    ClRecursosL.MtdEnvioEmail(correo, mensaje);
                }
            }
            
            return result;

        }



    }
}

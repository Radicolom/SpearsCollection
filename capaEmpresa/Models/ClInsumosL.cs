using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace capaEmpresa.Models
{
    public class ClInsumosL
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

        public int MtdGuardar(ClInsumoE objInsumoE, out string mensaje)
        {
            mensaje = string.Empty;
            int resul = 0;
            if (string.IsNullOrEmpty(objInsumoE.nombreInsumo) || string.IsNullOrWhiteSpace(objInsumoE.nombreInsumo))
            {
                mensaje = "El nombre no puede ser vacio";
            }
            if (objInsumoE.objMaterial.idMaterial == null || objInsumoE.objMaterial.idMaterial < 1)
            {
                if (!string.IsNullOrEmpty(objInsumoE.objMaterial.nombreMaterial) && !string.IsNullOrWhiteSpace(objInsumoE.objMaterial.nombreMaterial))
                {
                    //REGISTRO MATERIAL
                }
                else
                {
                    mensaje = "El material no puede ser nulo";
                }
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                if (objInsumoE.idInsumo == null || objInsumoE.idInsumo == 0)
                {
                    resul = objInsumo.MtdGuardar(objInsumoE, out mensaje);
                }
                else
                {
                    resul = 0; //Actualisar
                }
            }



            return resul;

        }

    }
}
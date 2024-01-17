using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace capaEmpresa.Models
{
    public class ClRolL
    {
        private string emailY = "speearscollectionbbc@gmail.com";
        private ClRolD objRolD = new ClRolD();
        public List<ClRolE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClRolE> lista = new List<ClRolE>();

            lista = objRolD.MtdListar(out mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(emailY, mensaje);
            }

            return lista;
        }

        public int MtdGuardar(ClRolE objRol, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;
            if (string.IsNullOrEmpty(objRol.nombreRol) || string.IsNullOrWhiteSpace(objRol.nombreRol))
            {
                mensaje = "El nombre no puede esta vacio o con espacios";
            }
            if (string.IsNullOrEmpty(mensaje))
            {
                result = new ClRolD().MtdGuardar(objRol, out mensaje);
                if (!string.IsNullOrEmpty(mensaje))
                {
                    ClRecursosL.MtdEnvioEmail(emailY, mensaje);
                }
                if (result == -1)
                {
                    mensaje = "El Rol ya esta registrado";
                }
            }
            return result;
        }

        public int MtdEliminar(ClRolE objRol, out string mensaje)
        {
            mensaje = string.Empty;
            int result = new ClRolD().MtdEliminar(objRol, out mensaje);
            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(emailY, mensaje);
                mensaje = "error al eliminar";
            }
            if (result == 0)
            {
                mensaje = "¡¡¡Ningun usuario deve tener el rol para eliminar!!!";
            }
            return result;
        }




    }
}
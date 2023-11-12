using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ClUsuarioL
    {
        private ClUsuarioD objUsuario = new ClUsuarioD();
        public List<ClUsuarioE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClUsuarioE> lista = objUsuario.MtdListar(out mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail("error", mensaje);
            }

            return lista;
        }

        public int MtdGuardar(ClUsuarioE objUsuarioE, out string mensaje)
        {
            int result = 0;
            mensaje = string.Empty;
            if (string.IsNullOrEmpty(objUsuarioE.documentoUsuario) || string.IsNullOrWhiteSpace(objUsuarioE.documentoUsuario))
            {
                mensaje = "El documento no pude ser vacio";
            }
            else if (string.IsNullOrEmpty(objUsuarioE.nombreUsuario))
            {
                mensaje = "El nombre no pude ser vacio";

            }
            else if (string.IsNullOrEmpty(objUsuarioE.apellidoUsuario))
            {
                mensaje = "El apellido no pude ser vacio";

            }
            else if (string.IsNullOrEmpty(objUsuarioE.correoUsuario) || string.IsNullOrWhiteSpace(objUsuarioE.correoUsuario))
            {
                mensaje = "El correo no pude ser vacio";

            }

            if (string.IsNullOrEmpty(mensaje))
            {
                string pasword = string.Empty;
                if (objUsuarioE.idUsuario == -1)
                {

                    objUsuarioE.claveUsuario = ClRecursosL.MtdEncrip(objUsuarioE.claveUsuario, out pasword);

                }
                result = objUsuario.MtdGuardar(objUsuarioE);
                if (result == 1)
                {
                    ClRecursosL.MtdEnvioEmail(objUsuarioE.correoUsuario, pasword);
                }
            }
             
            return result;
            
        }

        public int MtdEliminar(ClUsuarioE objUsuarioE)
        {
            return objUsuario.MtdEliminar(objUsuarioE);
        }


    }
}

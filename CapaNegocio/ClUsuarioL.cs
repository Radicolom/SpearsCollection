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
            return objUsuario.MtdListar();
        }

        public int MtdGuardar(ClUsuarioE objUsuarioE, out string mensaje)
        {
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
            else if (string.IsNullOrEmpty(objUsuarioE.correoUsuario) || string.IsNullOrWhiteSpace(objUsuarioE.documentoUsuario))
            {
                mensaje = "El correo no pude ser vacio";

            }

            if (string.IsNullOrEmpty(mensaje))
            {
                if (objUsuarioE.idUsuario == -1)
                {

                    objUsuarioE.claveUsuario = ClRecursosL.MtdEncrip(objUsuarioE.claveUsuario);

                }
                return objUsuario.MtdGuardar(objUsuarioE);
            }
            else
            {
                return 0;
            }
        }

        public int MtdEliminar(ClUsuarioE objUsuarioE)
        {
            return objUsuario.MtdEliminar(objUsuarioE);
        }


    }
}

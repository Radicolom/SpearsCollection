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
        private string emailY = "speearscollectionbbc@gmail.com";
        private ClUsuarioD objUsuario = new ClUsuarioD();
        public List<ClUsuarioE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClUsuarioE> lista = objUsuario.MtdListar(out mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(emailY, mensaje);
            }

            return lista;
        }

        public int MtdGuardar(ClUsuarioE objUsuarioE, out string mensaje)
        {
            int result = 0;
            mensaje = string.Empty;
            if (!objUsuarioE.documentoUsuario.All(char.IsDigit))
            {
                mensaje = "El documento debe contener solo números";
            } 
            else if (string.IsNullOrEmpty(objUsuarioE.documentoUsuario) || string.IsNullOrWhiteSpace(objUsuarioE.documentoUsuario))
            {
                mensaje = "El documento no pude ser vacio";
            }
            if (string.IsNullOrEmpty(objUsuarioE.nombreUsuario))
            {
                mensaje = "El nombre no pude ser vacio";

            }
            if (string.IsNullOrEmpty(objUsuarioE.apellidoUsuario))
            {
                mensaje = "El apellido no pude ser vacio";

            }
            if (string.IsNullOrEmpty(objUsuarioE.correoUsuario) || string.IsNullOrWhiteSpace(objUsuarioE.correoUsuario))
            {
                mensaje = "El correo no pude ser vacio";

            }
            if (objUsuarioE.objRol.idRol == null || objUsuarioE.objRol.idRol < 1)
            {
                mensaje = "El empleado deve tener un rol";
            }
            if (objUsuarioE.objCiudad.idCiudad == null || objUsuarioE.objCiudad.idCiudad < 1)
            {
                mensaje = "El empleado deve pertenecer a una ciudad";
            }
            
            if (string.IsNullOrEmpty(mensaje))
            {
                string pasword = string.Empty;
                if (objUsuarioE.idUsuario == 0)
                {
                    objUsuarioE.claveUsuario = ClRecursosL.MtdPassGene(out pasword);
                    result = objUsuario.MtdGuardar(objUsuarioE, out mensaje);
                    if (result == 1)
                    {
                        ClRecursosL.MtdEnvioEmail(objUsuarioE.correoUsuario, pasword);
                    }
                    else if (result == -1)
                    {
                        mensaje = "Datos ya registrados";
                    }
                }
                else
                {
                    result = objUsuario.MtdActualizar(objUsuarioE, out mensaje);
                }
                if (!string.IsNullOrEmpty(mensaje))
                {
                    ClRecursosL.MtdEnvioEmail(emailY, mensaje);
                }
            }
            return result;
        }

        public int MtdEliminar(ClUsuarioE objUsuarioE, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;

            result = objUsuario.MtdEliminar(objUsuarioE, out mensaje);
            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(emailY, mensaje);
            }

            return result;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClUsuarioE:ClRolE
    {
        public int idUsuario { get; set; }
        public string documentoUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string correoUsuario { get; set; }
        public string claveUsuario { get; set; }
        public bool estadoUsuario { get; set; }
        public string fechaRegistroUsuario { get; set; }
        
    }
}

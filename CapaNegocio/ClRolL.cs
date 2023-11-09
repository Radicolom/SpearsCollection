using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ClRolL
    {
        private ClRolD objRolD = new ClRolD();
        public List<ClRolE> MtdListar()
        {
            return objRolD.MtdListar();
        }
    }
}

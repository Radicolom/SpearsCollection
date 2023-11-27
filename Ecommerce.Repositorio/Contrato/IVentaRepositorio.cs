using Ecommerce.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositorio.Contrato
{
    public interface IVentaRepositorio : IGenericoRepositorio<VentaEcommerce>
    {
        Task<VentaEcommerce> Registrar(VentaEcommerce modelo);

    }
}

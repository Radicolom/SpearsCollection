using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class DetalleVentaEcommerceDTO
    {
        public int IdDetalleVentaE { get; set; }

        public int? IdProductoEcommerce { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Total { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class VentaEcommerceDTO
    {
        public int IdVentaE { get; set; }

        public int? IdUsuarioE { get; set; }

        public decimal? Total { get; set; }

       

        public virtual ICollection<DetalleVentaEcommerceDTO> DetalleVentaEcommerces { get; set; } = new List<DetalleVentaEcommerceDTO>();

    }
}

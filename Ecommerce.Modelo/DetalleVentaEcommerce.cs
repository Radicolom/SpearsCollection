using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class DetalleVentaEcommerce
{
    public int IdDetalleVentaE { get; set; }

    public int? IdVentaEcommerce { get; set; }

    public int? IdProductoEcommerce { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual ProductoEcommerce? IdProductoEcommerceNavigation { get; set; }

    public virtual VentaEcommerce? IdVentaEcommerceNavigation { get; set; }
}

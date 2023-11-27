using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class DetalleVenta
{
    public int IdDetalleVenta { get; set; }

    public int? CantidadProductoVenta { get; set; }

    public decimal? PrecioVenta { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProductoLocal { get; set; }

    public virtual ProductoLocal? IdProductoLocalNavigation { get; set; }

    public virtual Ventum? IdVentaNavigation { get; set; }
}

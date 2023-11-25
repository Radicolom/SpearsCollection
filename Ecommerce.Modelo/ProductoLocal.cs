using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class ProductoLocal
{
    public int IdProductoLocal { get; set; }

    public int? IdProducto { get; set; }

    public int? IdLocal { get; set; }

    public int? CantidadProductoLocal { get; set; }

    public string? PrecioProductoLocal { get; set; }

    public DateTime? FechaProductoLocal { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Local? IdLocalNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}

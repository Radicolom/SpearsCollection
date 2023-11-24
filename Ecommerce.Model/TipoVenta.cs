using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class TipoVenta
{
    public int IdTipoVenta { get; set; }

    public string? NombreTipoVenta { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}

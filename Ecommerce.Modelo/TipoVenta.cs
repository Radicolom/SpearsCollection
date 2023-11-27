using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class TipoVenta
{
    public int IdTipoVenta { get; set; }

    public string? NombreTipoVenta { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}

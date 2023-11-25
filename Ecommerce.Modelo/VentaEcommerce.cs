using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class VentaEcommerce
{
    public int IdVentaE { get; set; }

    public int? IdUsuarioE { get; set; }

    public decimal? Total { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleVentaEcommerce> DetalleVentaEcommerces { get; set; } = new List<DetalleVentaEcommerce>();

    public virtual UsuarioEcommerce? IdUsuarioENavigation { get; set; }
}

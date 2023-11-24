using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class DetalleCompra
{
    public int IdDetalleCompra { get; set; }

    public int? CantidadCompra { get; set; }

    public decimal? PrecioCompra { get; set; }

    public int? IdCompra { get; set; }

    public int? IdInsumo { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Insumo? IdInsumoNavigation { get; set; }
}

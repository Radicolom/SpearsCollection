using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class ProductoEcommerce
{
    public int IdProductoEcommerce { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCategoriaEcommerce { get; set; }

    public decimal? Precio { get; set; }

    public decimal? PrecioOferta { get; set; }

    public int? Cantidad { get; set; }

    public string? Imagen { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleVentaEcommerce> DetalleVentaEcommerces { get; set; } = new List<DetalleVentaEcommerce>();

    public virtual CategoriaEcommerce? IdCategoriaEcommerceNavigation { get; set; }
}

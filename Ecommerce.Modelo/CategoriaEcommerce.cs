using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class CategoriaEcommerce
{
    public int IdCategoriaEcommerce { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<ProductoEcommerce> ProductoEcommerces { get; set; } = new List<ProductoEcommerce>();
}

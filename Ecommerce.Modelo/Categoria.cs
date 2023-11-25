using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? DescripcionCategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}

using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Material
{
    public int IdMaterial { get; set; }

    public string? NombreMaterial { get; set; }

    public string? DescripcionMaterial { get; set; }

    public virtual ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}

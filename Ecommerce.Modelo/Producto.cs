using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? CodigoProducto { get; set; }

    public string? NombreProducto { get; set; }

    public string? DescripcionProducto { get; set; }

    public string? ImagenProducto { get; set; }

    public bool? EstadoProducto { get; set; }

    public DateTime? FechaProducto { get; set; }

    public int? IdMaterial { get; set; }

    public int? IdCategoria { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Material? IdMaterialNavigation { get; set; }

    public virtual ICollection<ProductoLocal> ProductoLocals { get; set; } = new List<ProductoLocal>();
}

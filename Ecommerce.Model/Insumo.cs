using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Insumo
{
    public int IdInsumo { get; set; }

    public string? NombreInsumo { get; set; }

    public int? CantidadInsumo { get; set; }

    public string? DescripcionInsumo { get; set; }

    public int? IdMaterial { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Material? IdMaterialNavigation { get; set; }

    public virtual ICollection<InsumoProvedor> InsumoProvedors { get; set; } = new List<InsumoProvedor>();
}

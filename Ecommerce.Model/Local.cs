using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Local
{
    public int IdLocal { get; set; }

    public string? NombreLocal { get; set; }

    public string? DireccionLocal { get; set; }

    public string? TelefonoLocal { get; set; }

    public virtual ICollection<ProductoLocal> ProductoLocals { get; set; } = new List<ProductoLocal>();
}

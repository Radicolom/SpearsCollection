using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Compra
{
    public int IdCompra { get; set; }

    public string? NumeroCompra { get; set; }

    public bool? EstadoCompra { get; set; }

    public DateTime? FechaCompra { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

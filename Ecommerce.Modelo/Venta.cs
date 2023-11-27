using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public string? NumeroVenta { get; set; }

    public string? EstadoVenta { get; set; }

    public DateTime? FechaVenta { get; set; }

    public string? ObservacionesVenta { get; set; }

    public int? IdTipoVenta { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdCliente { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual TipoVenta? IdTipoVentaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class InsumoEntrega
{
    public int IdInsumoEntrega { get; set; }

    public int? CantidadInsumoEntrega { get; set; }

    public DateTime? FechaInsumoEntrega { get; set; }

    public int? IdUsuario { get; set; }

    public int? EntregaSatelite { get; set; }

    public virtual EntregaSatelite? EntregaSateliteNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

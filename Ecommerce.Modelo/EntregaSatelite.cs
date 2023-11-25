using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class EntregaSatelite
{
    public int IdEntregaSatelite { get; set; }

    public int? CantidadEntregaSatelite { get; set; }

    public DateTime? FechaEntregaSatelite { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdProduccion { get; set; }

    public virtual ProduccionCorte? IdProduccionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<InsumoEntrega> InsumoEntregas { get; set; } = new List<InsumoEntrega>();
}

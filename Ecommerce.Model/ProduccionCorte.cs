using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class ProduccionCorte
{
    public int IdProduccionCorte { get; set; }

    public DateTime? FechaCorte { get; set; }

    public int? CantidadCorte { get; set; }

    public int? IdCorte { get; set; }

    public virtual ICollection<EntregaSatelite> EntregaSatelites { get; set; } = new List<EntregaSatelite>();

    public virtual Corte? IdCorteNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Corte
{
    public int IdCorte { get; set; }

    public string? NombrePrendaCorte { get; set; }

    public int? NumeroPiezasCorte { get; set; }

    public virtual ICollection<ProduccionCorte> ProduccionCortes { get; set; } = new List<ProduccionCorte>();
}

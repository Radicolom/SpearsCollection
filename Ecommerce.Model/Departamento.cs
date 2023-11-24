using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? NombreDepartamento { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();
}

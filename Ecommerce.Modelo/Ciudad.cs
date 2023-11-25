using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string? NombreCiudad { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

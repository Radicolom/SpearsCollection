using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class InsumoProvedor
{
    public int IdInsumoProvedor { get; set; }

    public int? IdInsumo { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Insumo? IdInsumoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

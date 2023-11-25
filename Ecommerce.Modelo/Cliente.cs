using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? DocumentoCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? ApellidoCliente { get; set; }

    public string? CorreoCliente { get; set; }

    public string? ClaveCliente { get; set; }

    public string? DireccionCliente { get; set; }

    public int? IdCiudad { get; set; }

    public DateTime? FechaCliente { get; set; }

    public virtual Ciudad? IdCiudadNavigation { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}

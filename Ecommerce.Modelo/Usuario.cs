using System;
using System.Collections.Generic;

namespace Ecommerce.Modelo;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? DocumentoUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? ApellidoUsuario { get; set; }

    public string? TellUsuario { get; set; }

    public string? CorreoUsuario { get; set; }

    public string? ClaveUsuario { get; set; }

    public string? DireccionUsuario { get; set; }

    public bool? EstadoUsuario { get; set; }

    public DateTime? FechaUsuario { get; set; }

    public int? IdCiudad { get; set; }

    public int? IdRol { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<EntregaSatelite> EntregaSatelites { get; set; } = new List<EntregaSatelite>();

    public virtual Ciudad? IdCiudadNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<InsumoEntrega> InsumoEntregas { get; set; } = new List<InsumoEntrega>();

    public virtual ICollection<InsumoProvedor> InsumoProvedors { get; set; } = new List<InsumoProvedor>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}

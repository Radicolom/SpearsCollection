using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

    public class ClDepartamentoE
    {
        public int idDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
    }

    public class ClCiudadE
    {
        public int idCiudad { get; set; }
        public string nombreCiudad { get; set; }
        public ClDepartamentoE objDepartamento { get; set; }
    }

    public class ClTipoVentaE
    {
        public int idTipoVenta { get; set; }
        public string nombreTipoVenta { get; set; }
    }

    public class ClRolE
    {
        public int idRol { get; set; }
        public string nombreRol { get; set; }
    }

    public class ClUsuarioE
    {
        public int idUsuario { get; set; }
        public string documentoUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string tellUsuario { get; set; }
        public string correoUsuario { get; set; }
        public string claveUsuario { get; set; }
        public string direccionUsuario { get; set; }
        public bool estadoUsuario { get; set; }
        public string fechaUsuario { get; set; }
        public ClCiudadE objCiudad { get; set; }
        public ClRolE objRol { get; set; }
    }

    public class ClClienteE
    {
        public int idCliente { get; set; }
        public string documentoCliente { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string correoCliente { get; set; }
        public string claveCliente { get; set; }
        public string direccionCliente { get; set; }
        public int idCiudad { get; set; }
        public string fechaCliente { get; set; }
        public ClCiudadE objCiudad { get; set; }
    }

    public class ClVentaE
    {
        public int idVenta { get; set; }
        public string numeroVenta { get; set; }
        public string estadoVenta { get; set; }
        public string fechaVenta { get; set; }
        public string observacionesVenta { get; set; }
        public int idTipoVenta { get; set; }
        public int idUsuario { get; set; }
        public int idCliente { get; set; }
        public ClTipoVentaE objTipoVenta { get; set; }
        public ClUsuarioE objUsuario { get; set; }
        public ClClienteE objCliente { get; set; }
    }

    public class ClCategoriaE
    {
        public int idCategoria { get; set; }
        public string descripcionCategoria { get; set; }
    }

    public class ClMaterialE
    {
        public int idMaterial { get; set; }
        public string nombreMaterial { get; set; }
        public string descripcionMaterial { get; set; }
    }

    public class ClProductoE
    {
        public int idProducto { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public string imagenProducto { get; set; }
        public bool estadoProducto { get; set; }
        public string fechaProducto { get; set; }
        public int idMaterial { get; set; }
        public int idCategoria { get; set; }
        public ClMaterialE objMaterial { get; set; }
        public ClCategoriaE objCategoria { get; set; }
    }

    public class ClLocalE
    {
        public int idLocal { get; set; }
        public string nombreLocal { get; set; }
        public string direccionLocal { get; set; }
        public string telefonoLocal { get; set; }
    }

    public class ClProductoLocalE
    {
        public int idProductoLocal { get; set; }
        public int idProducto { get; set; }
        public int idLocal { get; set; }
        public int cantidadProductoLocal { get; set; }
        public string precioProductoLocal { get; set; }
        public string fechaProductoLocal { get; set; }
        public ClProductoE objProducto { get; set; }
        public ClLocalE objLocal { get; set; }
    }

    public class ClDetalleVentaE
    {
        public int idDetalleVenta { get; set; }
        public int cantidadProductoVenta { get; set; }
        public decimal precioVenta { get; set; }
        public int idVenta { get; set; }
        public int idProductoLocal { get; set; }
        public ClVentaE objVenta { get; set; }
        public ClProductoLocalE objProductoLocal { get; set; }
    }

    public class ClProveedorE
    {
        public int idProveedor { get; set; }
        public string documentoProveedor { get; set; }
        public string nombreProveedor { get; set; }
        public string tellProveedor { get; set; }
    }

    public class ClCompraE
    {
        public int idCompra { get; set; }
        public string numeroCompra { get; set; }
        public bool estadoCompra { get; set; }
        public string fechaCompra { get; set; }
        public string imagenCompra { get; set; } 
        public ClUsuarioE objProveedor { get; set; }
    }

    public class ClInsumoE
    {
        public int idInsumo { get; set; }
        public string nombreInsumo { get; set; }
        public int cantidadInsumo { get; set; }
        public string imagenInsumo { get; set; }
        public string descripcionInsumo { get; set; }
        public ClMaterialE objMaterial { get; set; }
    }

    public class ClDetalleCompraE
    {
        public int idDetalleCompra { get; set; }
        public int cantidadCompra { get; set; }
        public decimal precioCompra { get; set; }
        public ClCompraE objCompra { get; set; }
        public ClInsumoE objInsumo { get; set; }
    }

    public class ClInsumoProveedorE
    {
        public int idInsumoProveedor { get; set; }
        public int idInsumo { get; set; }
        public int idProveedor { get; set; }
        public ClInsumoE objInsumo { get; set; }
        public ClProveedorE objProveedor { get; set; }
    }

    public class ClCorteE
    {
        public int idCorte { get; set; }
        public string nombrePrendaCorte { get; set; }
        public int numeroPiezasCorte { get; set; }
    }

    public class ClProduccionCorteE
    {
        public int idProduccionCorte { get; set; }
        public string fechaCorte { get; set; }
        public int cantidadCorte { get; set; }
        public int idCorte { get; set; }
        public ClCorteE objCorte { get; set; }
    }

    public class ClEntregaSateliteE
    {
        public int idEntregaSatelite { get; set; }
        public int cantidadEntregaSatelite { get; set; }
        public string fechaEntregaSatelite { get; set; }
        public int idUsuario { get; set; }
        public int idProduccion { get; set; }
        public ClUsuarioE objUsuario { get; set; }
        public ClProduccionCorteE objProduccionCorte { get; set; }
    }

    public class ClInsumoEntregaE
    {
        public int idInsumoEntrega { get; set; }
        public int cantidadInsumoEntrega { get; set; }
        public string fechaInsumoEntrega { get; set; }
        public int idUsuario { get; set; }
        public int entregaSatelite { get; set; }
        public ClUsuarioE objUsuario { get; set; }
        public ClEntregaSateliteE objEntregaSatelite { get; set; }
    }


}

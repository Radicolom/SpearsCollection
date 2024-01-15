using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface ICarritoServicio
    {

        event Action MostarItems;

        int CantidadProductos();
        Task AgregarAlCarrito(CarritoDTO modelo);
        Task EliminarDeCarrito(int idProducto);
        Task<List<CarritoDTO>> DevolverCarrito();
        Task LimpiarCarrito();

    }
}

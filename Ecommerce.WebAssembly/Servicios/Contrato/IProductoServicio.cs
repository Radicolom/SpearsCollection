using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IProductoServicio
    {

        Task<ResponseDTO<List<ProductoEcommerceDTO>>> Lista(string buscar);
        Task<ResponseDTO<List<ProductoEcommerceDTO>>> Catalogo(string categoria, string buscar);
        Task<ResponseDTO<ProductoEcommerceDTO>> Obtener(int id);
        Task<ResponseDTO<ProductoEcommerceDTO>> Crear(ProductoEcommerceDTO modelo);
        Task<ResponseDTO<bool>> Editar(ProductoEcommerceDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}

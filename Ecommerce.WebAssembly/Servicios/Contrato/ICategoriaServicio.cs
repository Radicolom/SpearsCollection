using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface ICategoriaServicio
    {

        Task<ResponseDTO<List<CategoriaEcommerceDTO>>> Lista(string buscar);
        Task<ResponseDTO<CategoriaEcommerceDTO>> Obtener(int id);
        Task<ResponseDTO<CategoriaEcommerceDTO>> Crear(CategoriaEcommerceDTO modelo);
        Task<ResponseDTO<bool>> Editar(CategoriaEcommerceDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}

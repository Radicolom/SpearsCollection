using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IUsuarioServicio
    {

        Task<ResponseDTO<List<UsuarioEcommerceDTO>>> Lista(string rol, string buscar);
        Task<ResponseDTO<UsuarioEcommerceDTO>>Obtener(int id);
        Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
        Task<ResponseDTO<UsuarioEcommerceDTO>> Crear(UsuarioEcommerceDTO modelo);
        Task<ResponseDTO<bool>> Editar(UsuarioEcommerceDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);



    }
}

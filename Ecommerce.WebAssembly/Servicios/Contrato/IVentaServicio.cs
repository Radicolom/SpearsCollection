using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IVentaServicio
    {

        
        Task<ResponseDTO<VentaEcommerceDTO>> Registrar(VentaEcommerceDTO modelo);
        
    }
}

using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Servicios.Implementacion
{
    public class ProductoServicio: IProductoServicio
    {

        private readonly HttpClient _httpClient;

        public ProductoServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ProductoEcommerceDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoEcommerceDTO>>>($"Producto/Catalogo/{buscar}");

        }

        public async Task<ResponseDTO<ProductoEcommerceDTO>> Crear(ProductoEcommerceDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Producto/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoEcommerceDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Editar(ProductoEcommerceDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Producto/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Producto/Eliminar/{id}");

        }

        public async Task<ResponseDTO<List<ProductoEcommerceDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoEcommerceDTO>>>($"Producto/Lista/{buscar}");

        }

        public async Task<ResponseDTO<ProductoEcommerceDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoEcommerceDTO>>($"Producto/Obtener/{id}");

        }
    }
}

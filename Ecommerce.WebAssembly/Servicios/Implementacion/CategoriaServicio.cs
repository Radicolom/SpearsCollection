using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Servicios.Implementacion
{
    public class CategoriaServicio:ICategoriaServicio
    {

        private readonly HttpClient _httpClient;

        public CategoriaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoriaEcommerceDTO>> Crear(CategoriaEcommerceDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaEcommerceDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Editar(CategoriaEcommerceDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Categoria/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<CategoriaEcommerceDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaEcommerceDTO>>>($"Categoria/Lista/{buscar}");
        }

        public async Task<ResponseDTO<CategoriaEcommerceDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaEcommerceDTO>>($"Usuario/Obtener/{id}");
        }
    }
}

using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;


namespace Ecommerce.WebAssembly.Servicios.Implementacion
{
    public class UsuarioServicio: IUsuarioServicio
    {

        private readonly HttpClient _httpClient;

        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacion", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();
            return result;
        }

        public async Task<ResponseDTO<UsuarioEcommerceDTO>> Crear(UsuarioEcommerceDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioEcommerceDTO>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Editar(UsuarioEcommerceDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<UsuarioEcommerceDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioEcommerceDTO>>>($"Usuario/Lista/{rol}/{buscar}");

        }
        public async Task<ResponseDTO<UsuarioEcommerceDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioEcommerceDTO>>($"Usuario/Obtener/{id}");

        }
    }
}

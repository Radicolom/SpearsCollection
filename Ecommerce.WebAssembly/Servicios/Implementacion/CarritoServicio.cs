using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;

namespace Ecommerce.WebAssembly.Servicios.Implementacion
{
    public class CarritoServicio : ICarritoServicio
    {

        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;

        public CarritoServicio(ILocalStorageService localStorageService,
                                ISyncLocalStorageService syncLocalStorageService,
                                IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;

        }

        public event Action MostarItems;

        public async Task AgregarAlCarrito(CarritoDTO modelo)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if (carrito == null) ;
                carrito = new List<CarritoDTO>();

                var encontrado = carrito.FirstOrDefault(c => c.Producto.IdProductoEcommerce == modelo.Producto.IdProductoEcommerce);
                if (encontrado != null)
                    carrito.Remove(encontrado);

                carrito.Add(modelo);
                await _localStorageService.SetItemAsync("carrito", carrito);

                if (encontrado != null)
                    _toastService.ShowSuccess("El Producto Se Actualizo Exitosamente En El Carrito");
                else
                    _toastService.ShowSuccess("El Producto Fue Agregado Al Carrito Exitosamente");

                MostarItems.Invoke();

            }
            catch (Exception ex)
            {
                _toastService.ShowError("El Producto No Se Pudo Agregar Al Carrito");


            }
        }

        public int CantidadProductos()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");
            return carrito == null ? 0 : carrito.Count();
        }

        public async Task<List<CarritoDTO>> DevolverCarrito()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
            if (carrito == null)
                carrito = new List<CarritoDTO>();

            return carrito;
        }

        public async Task EliminarDeCarrito(int idProducto)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if (carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProductoEcommerce == idProducto);
                    if (elemento != null)
                    {
                        carrito.Remove(elemento);

                        await _localStorageService.SetItemAsync("carrito", carrito);
                        MostarItems.Invoke();
                    }
                }

            }
            catch
            {

            }
        }

        public async Task LimpiarCarrito()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            MostarItems.Invoke();

        }
    }
}
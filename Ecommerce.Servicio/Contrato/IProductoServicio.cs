using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;

namespace Ecommerce.Servicio.Contrato
{
    public interface IProductoServicio
    {

        Task<List<ProductoEcommerceDTO>> Lista( string buscar);
        Task<List<ProductoEcommerceDTO>> Catalogo(string categoria,string buscar);

        Task<ProductoEcommerceDTO> Obtener(int id);
        Task<ProductoEcommerceDTO> Crear(ProductoEcommerceDTO modelo);
        Task<bool> Editar(ProductoEcommerceDTO modelo);
        Task<bool> Eliminar(int id);
    }
}

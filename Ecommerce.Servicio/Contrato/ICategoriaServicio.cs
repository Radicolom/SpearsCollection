using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace Ecommerce.Servicio.Contrato
{
    public interface ICategoriaServicio
    {
        Task<List<CategoriaEcommerceDTO>> Lista( string buscar);
        Task<CategoriaEcommerceDTO> Obtener(int id);
        Task<CategoriaEcommerceDTO> Crear(CategoriaEcommerceDTO modelo);
        Task<bool> Editar(CategoriaEcommerceDTO modelo);
        Task<bool> Eliminar(int id);
    }
}

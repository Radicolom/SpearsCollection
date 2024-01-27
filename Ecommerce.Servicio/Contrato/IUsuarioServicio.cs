using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace Ecommerce.Servicio.Contrato
{
    public interface IUsuarioServicio
    {
        Task<List<UsuarioEcommerceDTO>> Lista(string rol,string buscar);
        Task<UsuarioEcommerceDTO> Obtener(int id);
        Task<SesionDTO> Autorizacion(LoginDTO modelo);
        Task<UsuarioEcommerceDTO> Crear(UsuarioEcommerceDTO modelo);
        Task<bool>Editar(UsuarioEcommerceDTO modelo);
        Task<bool> Eliminar(int id);




    }
}

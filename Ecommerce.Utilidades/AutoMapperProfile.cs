using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AutoMapper;
using Ecommerce.Modelo;
using Ecommerce.DTO;

namespace Ecommerce.Utilidades
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioEcommerce, UsuarioEcommerceDTO>();
            CreateMap<UsuarioEcommerce, SesionDTO>();
            CreateMap<UsuarioEcommerceDTO, UsuarioEcommerce>();

            CreateMap<CategoriaEcommerce, CategoriaEcommerceDTO>();
            CreateMap<CategoriaEcommerceDTO, CategoriaEcommerce>();

            CreateMap<ProductoEcommerce, ProductoEcommerceDTO>();
            CreateMap<ProductoEcommerceDTO, ProductoEcommerce>().ForMember(destino =>
                destino.IdCategoriaEcommerceNavigation,
                opt => opt.Ignore()
            );

            CreateMap<DetalleVentaEcommerce, DetalleVentaEcommerceDTO>();
            CreateMap<DetalleVentaEcommerceDTO, DetalleVentaEcommerce>();

            CreateMap<VentaEcommerce, VentaEcommerceDTO>();
            CreateMap<VentaEcommerceDTO, VentaEcommerce>();
        }
    }
}

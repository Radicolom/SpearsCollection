using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using Ecommerce.Modelo;
using Ecommerce.DTO;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Servicio.Contrato;
using AutoMapper;

namespace Ecommerce.Servicio.Implementacion
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly IGenericoRepositorio<UsuarioEcommerce> _usuarioRepositorio;
        private readonly IGenericoRepositorio<ProductoEcommerce> _productoRepositorio;
        private readonly IVentaRepositorio _ventaRepositorio;


        public DashboardServicio(IVentaRepositorio ventaRepositorio,IGenericoRepositorio<UsuarioEcommerce>usuarioRepositorio, 
            IGenericoRepositorio<ProductoEcommerce> productoRepositorio)
        {

            _ventaRepositorio = ventaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _productoRepositorio = productoRepositorio;

        }

        private string IngresosEco()
        {
            var consulta = _ventaRepositorio.Consultar();
            decimal?  ingresos = consulta.Sum(y=> y.Total);

            return Convert.ToString(ingresos);
        }


        private int VentasEco()
        {
            var consulta = _ventaRepositorio.Consultar();
            int totalVentas = consulta.Count();

            return totalVentas;
        }

        private int ClientesEco()
        {
            var consulta = _usuarioRepositorio.Consultar(u => u.Rol.ToLower() == "Cliente");
            int totalClientes = consulta.Count();

            return totalClientes;
        }

        private int ProductosEco()
        {
            var consulta = _productoRepositorio.Consultar();
            int totalProductos = consulta.Count();

            return totalProductos;
        }

        public DashboardDTO Resumen()
        {
            try
            {

                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngresos = IngresosEco(),
                    TotalVentas = VentasEco(),
                    TotalCliente = ClientesEco(),
                    TotalProductos = ProductosEco(),
                };

                return dto;

            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}

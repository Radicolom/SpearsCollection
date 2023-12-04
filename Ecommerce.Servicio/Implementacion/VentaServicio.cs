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
    public  class VentaServicio : IVentaServicio
    {
        private readonly IVentaRepositorio _modeloRepositorio;
        private readonly IMapper _mapper;

        public VentaServicio(IVentaRepositorio modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async  Task<VentaEcommerceDTO> Registrar(VentaEcommerceDTO modelo)
        {
            try
            {
                var DbModelo = _mapper.Map<VentaEcommerce>(modelo);
                var ventaGenerada = await _modeloRepositorio.Registrar(DbModelo);

                if (ventaGenerada.IdVentaE == 0)
                   
                    throw new TaskCanceledException("No se logro registrar");

                return _mapper.Map<VentaEcommerceDTO>(ventaGenerada);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

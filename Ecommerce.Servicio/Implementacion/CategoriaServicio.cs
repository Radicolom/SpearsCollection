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
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly IGenericoRepositorio<CategoriaEcommerce> _modeloRepositorio;
        private readonly IMapper _mapper;

        public CategoriaServicio(IGenericoRepositorio<CategoriaEcommerce> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<CategoriaEcommerceDTO> Crear(CategoriaEcommerceDTO modelo)
        {
            try
            {
                var DbModelo = _mapper.Map<CategoriaEcommerce>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(DbModelo);

                if (rspModelo.IdCategoriaEcommerce != 0)
                    return _mapper.Map<CategoriaEcommerceDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se pudo crear");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(CategoriaEcommerceDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdCategoriaEcommerce == modelo.IdCategoriaEcommerce);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                        throw new TaskCanceledException("No se logro Editar");
                    return respuesta;


                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdCategoriaEcommerce == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _modeloRepositorio.Eliminar(fromDbModelo);
                    if (!respuesta)
                        throw new TaskCanceledException("No se logro Eliminar");

                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro resultados");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoriaEcommerceDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => string.Concat(p.Nombre.ToLower()).Contains(buscar.ToLower()));
                List<CategoriaEcommerceDTO> lista = _mapper.Map<List<CategoriaEcommerceDTO>>(await consulta.ToListAsync());
                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaEcommerceDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdCategoriaEcommerce == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<CategoriaEcommerceDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontro resultados");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

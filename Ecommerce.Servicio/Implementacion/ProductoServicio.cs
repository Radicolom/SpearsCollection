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
    public class ProductoServicio : IProductoServicio
    {
        private readonly IGenericoRepositorio<ProductoEcommerce> _modeloRepositorio;
        private readonly IMapper _mapper;

        public ProductoServicio(IGenericoRepositorio<ProductoEcommerce> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<List<ProductoEcommerceDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Nombre.ToLower().Contains(buscar.ToLower()) && p.IdCategoriaEcommerceNavigation.Nombre.ToLower().Contains(categoria.ToLower()));

                List<ProductoEcommerceDTO> lista = _mapper.Map<List<ProductoEcommerceDTO>>(await consulta.ToListAsync());
                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoEcommerceDTO> Crear(ProductoEcommerceDTO modelo)
        {
            try
            {
                var DbModelo = _mapper.Map<ProductoEcommerce>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(DbModelo);

                if (rspModelo.IdProductoEcommerce != 0)
                    return _mapper.Map<ProductoEcommerceDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se pudo crear");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  async Task<bool> Editar(ProductoEcommerceDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdProductoEcommerce == modelo.IdProductoEcommerce);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Precio = modelo.Precio;
                    fromDbModelo.PrecioOferta = modelo.PrecioOferta;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.Imagen = modelo.Imagen;
                    fromDbModelo.IdCategoriaEcommerce = modelo.IdCategoriaEcommerce;

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
                var consulta = _modeloRepositorio.Consultar(p => p.IdProductoEcommerce == id);
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

        public async Task<List<ProductoEcommerceDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Nombre.ToLower().Contains(buscar.ToLower()));

                consulta = consulta.Include(c => c.IdCategoriaEcommerceNavigation);

                List<ProductoEcommerceDTO> lista = _mapper.Map<List<ProductoEcommerceDTO>>(await consulta.ToListAsync());
                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoEcommerceDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdProductoEcommerce == id);
                consulta = consulta.Include(c => c.IdCategoriaEcommerceNavigation);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<ProductoEcommerceDTO>(fromDbModelo);
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

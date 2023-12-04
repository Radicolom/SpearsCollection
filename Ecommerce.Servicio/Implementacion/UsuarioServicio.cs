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
    public class UsuarioServicio : IUsuarioServicio
    {
       private readonly IGenericoRepositorio<UsuarioEcommerce> _modeloRepositorio;
       private readonly IMapper _mapper;

        public UsuarioServicio(IGenericoRepositorio<UsuarioEcommerce> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;

        }

        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                 var consulta = _modeloRepositorio.Consultar(p=>p.Correo==modelo.Correo && p.Clave == modelo.Clave);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();
                if (fromDbModelo != null)
                    return _mapper.Map<SesionDTO>(fromDbModelo);
                else
                    throw new TaskCanceledException("No se encontro coincidencia alguna");

                
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<UsuarioEcommerceDTO> Crear(UsuarioEcommerceDTO modelo)
        {
            try
            {
                var DbModelo = _mapper.Map<UsuarioEcommerce>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(DbModelo);

                if (rspModelo.IdUsuarioE != 0)
                    return _mapper.Map<UsuarioEcommerceDTO>(rspModelo);
                else
                    throw new TaskCanceledException("No se pudo crear");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(UsuarioEcommerceDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p=>p.IdUsuarioE == modelo.IdUsuarioE);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.NombreCompleto = modelo.NombreCompleto;
                    fromDbModelo.Correo = modelo.Correo;
                    fromDbModelo.Clave = modelo.Clave;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuarioE == id);
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

        public async Task<List<UsuarioEcommerceDTO>> Lista(string rol, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Rol == rol && string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower()));
                List<UsuarioEcommerceDTO> lista = _mapper.Map<List<UsuarioEcommerceDTO>>(await consulta.ToListAsync());
                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioEcommerceDTO> Obtener(int id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuarioE == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                    return _mapper.Map<UsuarioEcommerceDTO>(fromDbModelo);
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

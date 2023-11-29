using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Modelo;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repositorio.DBContext;

namespace Ecommerce.Repositorio.Implementacion
{
    public class VentaRepositorio : GenericoRepositorio<VentaEcommerce>,IVentaRepositorio
    {
        private readonly DbProyectoSpContext _dbContext;
       
        public VentaRepositorio(DbProyectoSpContext dbContext) : base(dbContext) 
            
        {
            _dbContext = dbContext;
        }

        public async Task<VentaEcommerce> Registrar(VentaEcommerce modelo)
        {
            VentaEcommerce ventaGenerada = new VentaEcommerce();
            using (var Traspaso = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVentaEcommerce dv in modelo.DetalleVentaEcommerces)
                    {
                        ProductoEcommerce producto_encontrado = _dbContext.ProductoEcommerces.Where(pt => pt.IdProductoEcommerce == dv.IdProductoEcommerce).First();

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;
                        _dbContext.ProductoEcommerces.Update(producto_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();
                    await _dbContext.VentaEcommerces.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();
                    ventaGenerada = modelo;
                    Traspaso.Commit();
                }
                catch
                {
                    Traspaso.Rollback();
                    throw;
                }
            }
            return ventaGenerada;
        }
    }
}

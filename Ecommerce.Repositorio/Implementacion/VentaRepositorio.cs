using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Modelo;
using Ecommerce.Repositorio.Contrato;
using Ecommerce.Repostorio.DBContext;

namespace Ecommerce.Repositorio.Implementacion
{
    public class VentaRepositorio :GenericoRepositorio<Venta>.IVentaReposotorio
    {
        private readonly DbProyectoSpContext _dbContext;
        public VentaRepositorio(DbProyectoSpContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<Venta> Registrar(Venta modelo) 
        {
          Venta ventaGenerada = new Venta();
            using (var Traspaso = _dbContext.Database.BeginTransaction()) 
            {
                try
                {
                   foreach ( DetalleVenta dv in modelo.DetalleVenta)
                   {
                        Producto producto_encontrado = _dbContext.Productos.Where(pt => pt.IdProducto == dv.IdDetalleVenta).First();

                        producto_encontrado.ProductoLocals = producto_encontrado.CantidadProductoLocal - dv.CantidadProductoVenta;
                        _dbContext.Productos.Update(producto_encontrado);
                   }
                    await _dbContext.SaveChangesAsync();
                    await _dbContext.Venta.AddAsync(modelo);
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

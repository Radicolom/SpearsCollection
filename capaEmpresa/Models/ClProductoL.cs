using CapaDatos;
using CapaEntidad;
using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace capaEmpresa.Models
{
    public class ClProductoL
    {
        private ClProductoD objProducto = new ClProductoD();

        public int MtdGuardar(ClProductoE producto, HttpPostedFileBase imagen, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;

            if (string.IsNullOrEmpty(producto.descripcionProducto))
            {
                mensaje = "La descripcion no puede estar vacia";
            }
            if (string.IsNullOrEmpty(producto.objMaterial.nombreMaterial))
            {
                mensaje = "El material no puede ser nulo";
            }
            if (producto.idCategoria < 1 || producto.idCategoria == null)
            {
                mensaje = "Se deve seleccionar una categoria";
            }
            if (string.IsNullOrEmpty(producto.nombreProducto))
            {
                mensaje = "El nombre del producto no puede estar vacio";
            }
            if (string.IsNullOrEmpty(producto.codigoProducto))
            {
                mensaje = "El codigo del producto no puede ser nulo";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                try
                {
                    if (imagen != null)
                    {
                        // Obtén la ruta del directorio padre de CapaEmpresa
                        string rutaBase = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;

                        // Combina la ruta del directorio padre con la carpeta Imagen en la capa de entidad
                        string rutaFisica = Path.Combine(rutaBase, "..", "CapaEntidad", "Imagen");

                        string extension = Path.GetExtension(imagen.FileName);

                        //// Generar un nombre de archivo único para evitar colisiones
                        string nombreArchivo = "Producto" + Guid.NewGuid().ToString() + extension;

                        //// Combina la ruta de guardado con el nombre del archivo
                        string rutaCompleta = Path.Combine(rutaFisica, nombreArchivo);

                        //// Guarda la imagen en la ruta especificada
                        imagen.SaveAs(rutaCompleta);

                        //// Almacena la ruta relativa del archivo en tu objeto ClProductoE
                        producto.imagenProducto = Path.Combine("CapaEntidad", "Imagen", nombreArchivo);

                        result = 1;
                    }
                }
                catch (Exception exp)
                {
                    mensaje = exp.ToString();
                }

                if (string.IsNullOrEmpty(mensaje) && result == 1)
                {
                    result = objProducto.MtdGuardar(producto, out mensaje);
                }

            }
            else
            {
                mensaje = "El objeto producto es nulo";
            }
            return result;
        }





























    }
}
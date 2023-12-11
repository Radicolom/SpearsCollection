using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace capaEmpresa.Models
{
    public class ClProductoL
    {
        private string _id;
        private ClProductoD objProducto = new ClProductoD();

        public int MtdGuardar(ClProductoE producto, out string mensaje)
        {
            mensaje = string.Empty;
            int result = 0;

            try
            {
                if (producto.imagenProducto != null)
                {
                    string rutaGuardar = ConfigurationManager.AppSettings["serviFotos"];
                    string extension = Path.GetExtension(producto.imagenProducto);

                    // Generar un nombre de archivo único para evitar colisiones
                    string nombreArchivo = Guid.NewGuid().ToString() + extension;

                    // Combina la ruta de guardado con el nombre del archivo
                    string rutaCompleta = Path.Combine(rutaGuardar, nombreArchivo);

                    // Guarda la imagen en la ruta especificada
                    File.WriteAllBytes(rutaCompleta, Convert.FromBase64String(producto.imagenProducto));

                    // Almacena la ruta del archivo en tu objeto ClProductoE
                    producto.imagenProducto = rutaCompleta;


                    result = 1;
                }

            }
            catch (Exception exp)
            {
                mensaje = exp.ToString();
                throw;
            }
            



            return result;

        }



    }
}
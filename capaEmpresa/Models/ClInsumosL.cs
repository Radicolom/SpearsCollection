using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace capaEmpresa.Models
{
    public class ClInsumosL
    {
        private ClInsumoD objInsumo = new ClInsumoD();
        private string emailY = "";

        public List<ClInsumoE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClInsumoE> lista = objInsumo.MtdListar(out mensaje);
            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(emailY, mensaje);
            }

            return lista;
        }

		public int MtdGuardar(ClDetalleCompraE objInsumoE, HttpPostedFileBase imagen, out string mensaje)
        {
            mensaje = string.Empty;
            int resul = 0;
            if (string.IsNullOrEmpty(objInsumoE.objInsumo.nombreInsumo) || string.IsNullOrWhiteSpace(objInsumoE.objInsumo.nombreInsumo))
            {
                mensaje = "El nombre no puede ser vacio";
            }
            if (string.IsNullOrEmpty(objInsumoE.objInsumo.objMaterial.nombreMaterial) && objInsumoE.objInsumo.objMaterial.idMaterial < 1)
            {
                    mensaje = "El material no puede ser nulo";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                if (objInsumoE.objInsumo.idInsumo == null || objInsumoE.objInsumo.idInsumo == 0)
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
							string nombreArchivo = "Insumo" + Guid.NewGuid().ToString() + extension;

							//// Combina la ruta de guardado con el nombre del archivo
							string rutaCompleta = Path.Combine(rutaFisica, nombreArchivo);

							//// Guarda la imagen en la ruta especificada
							imagen.SaveAs(rutaCompleta);

							//// Almacena la ruta relativa del archivo en tu objeto ClProductoE
							objInsumoE.objInsumo.imagenInsumo = Path.Combine("CapaEntidad", "Imagen", nombreArchivo);

							resul = objInsumo.MtdGuardar(objInsumoE, out mensaje);
						}
					}
					catch (Exception exp)
					{
						mensaje = exp.ToString();
					}
                }
                else
                {
                    resul = 0; //Actualisar
                }
            }



            return resul;

        }

    }
}
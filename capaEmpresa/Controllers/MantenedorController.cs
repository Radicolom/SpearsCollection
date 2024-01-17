using capaEmpresa.Models;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace capaEmpresa.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Categoria()
        {
            return View();
        }

        public ActionResult Marca()
        {
            return View();
        }

        public ActionResult Producto()
        {
            return View();
        }

        [HttpGet]
        public JsonResult MtdListarMaterial()
        {
            List<ClMaterialE> lista = new ClMaterialL().MtdListar();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }









        [HttpPost]
        public JsonResult MtdGuardarProducto(string objproducto2, HttpPostedFileBase imagen)
        {
            // Convierte la cadena JSON en un objeto C#
            ClProductoE objproducto = Newtonsoft.Json.JsonConvert.DeserializeObject<ClProductoE>(objproducto2);
            int result = 0;
            string mensaje = string.Empty;

            if (objproducto != null)
            {
                result = new ClProductoL().MtdGuardar(objproducto, imagen, out mensaje);               
            }
            else
            {
                mensaje = "Los campos son obligatorios";
            }

            return Json(new { data = result, mensaje = mensaje });
        }




    }
}
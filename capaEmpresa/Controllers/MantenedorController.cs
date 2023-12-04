using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            return Json(new { data = lista}, JsonRequestBehavior.AllowGet);
        }









        [HttpPost]
        public JsonResult MtdGuardarProducto(ClProductoE producto, HttpPostedFileBase imagen)
        {
            string mensaje = string.Empty;
            int result = 0;


            if (producto != null)
            {

            }
            if (imagen != null)
            {
                string ruta = ConfigurationManager.AppSettings["ServidorFotos"];
            }
            return Json(new { data = result, mensaje = mensaje});
        }
    
        
    
    
    }
}
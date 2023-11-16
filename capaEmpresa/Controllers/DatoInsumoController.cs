using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace capaEmpresa.Controllers
{
    public class DatoInsumoController : Controller
    {
        // GET: DatoInsumo
        public ActionResult Compra()
        {
            return View();
        }

        public ActionResult Insumo()
        {
            return View();
        }

        public ActionResult cortes()
        {
            return View();
        }

        public ActionResult EntregasSatelite()
        {
            return View();
        }

        [HttpGet]
        public JsonResult MtdListarCompra() 
        {
            List<ClDetalleCompraE> objLista = new ClCompraL().MtdListar();

            return Json(new { data = objLista}, JsonRequestBehavior.AllowGet);
        
        }

        [HttpPost]
        public JsonResult MtdGuardar(ClDetalleCompraE objCompra)
        {
            string mensaje = string.Empty;
            int result = 0;
            return Json(new { data = result, mensaje = mensaje });
        }

        [HttpPost]
        public JsonResult MtdEliminar(ClDetalleCompraE objCompra)
        {
            string mensaje = string.Empty;
            int result = 0;
            return Json(new { data = result, mensaje = mensaje });
        }

        [HttpGet]
        public JsonResult MtdListarProveedor()
        {
            List<ClUsuarioE> objLista = new List<ClUsuarioE>();
            objLista = new ClProvedorL().MtdListar();

            return Json(new { data = objLista }, JsonRequestBehavior.AllowGet);
        }

    }
}
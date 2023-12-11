using capaEmpresa.Models;
using CapaEntidad;
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

        //Compras
        [HttpGet]
        public JsonResult MtdListarCompra()
        {
            List<ClDetalleCompraE> objLista = new ClCompraL().MtdListar();
            return Json(new { data = objLista }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult MtdGuardar(ClDetalleCompraE objCompra)
        //{
        //    string mensaje = string.Empty;
        //    int result = 0;
        //    return Json(new { data = result, mensaje = mensaje });
        //}

        //[HttpPost]
        //public JsonResult MtdEliminar(ClDetalleCompraE objCompra)
        //{
        //    string mensaje = string.Empty;
        //    int result = 0;
        //    return Json(new { data = result, mensaje = mensaje });
        //}

        //Proveedores
        [HttpGet]
        public JsonResult MtdListarProveedor()
        {
            List<ClUsuarioE> objLista = new List<ClUsuarioE>();
            objLista = new ClProvedorL().MtdListar();

            return Json(new { data = objLista }, JsonRequestBehavior.AllowGet);
        }


        //Satelite
        [HttpGet]
        public JsonResult MtdListarSatelite()
        {
            List<ClUsuarioE> objLista = new List<ClUsuarioE>();
            objLista = new ClSateliteL().MtdListar();

            return Json(new { data = objLista }, JsonRequestBehavior.AllowGet);
        }


        //Cortes
        [HttpGet]
        public JsonResult MtdListarCorte()
        {
            List<ClCorteE> lista = new ClCorteL().MtdListar();
            return Json(new { data = lista });

        }

        //[HttpPost]
        //public JsonResult MtdGuardarCorte(ClCorteE objCorte)
        //{
        //    string mensaje = string.Empty;
        //    int result = 0;
        //    return Json(new { data = result, mensaje = mensaje });
        //}

        //[HttpPost]
        //public JsonResult MtdEliminarCorte(ClCorteE objCorte)
        //{
        //    string mensaje = string.Empty;
        //    int result = 0;
        //    return Json(new { data = result, mensaje = mensaje });
        //}


        //Insumos
        [HttpGet]
        public JsonResult MtdListarInsumo()
        {
            string mensaje = string.Empty;
            List<ClInsumoE> lista = new ClInsumosL().MtdListar();
            return Json(new { data = lista, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult MtdGuardarInsumo(ClInsumoE objInsumo)
        //{
        //    string mensaje = string.Empty;
        //    int result = 0;

        //    return Json(new { data = result, mensaje = mensaje });
        //}

        //[HttpPost]
        //public JsonResult MtdEliminarInsumos(ClInsumoE objInsumo)
        //{
        //    string mensaje = string.Empty;

        //    return Json(new { data = objInsumo, mensaje = mensaje });
        //}

        //Materiales
        [HttpPost]
        public JsonResult MtdGuardarMaterial(ClMaterialE objMaterial)
        {
            string mensaje = string.Empty;
            int result = new ClMaterialL().MtdGuardar(objMaterial, out mensaje);

            return Json(new { data = result, mensaje = mensaje });
        }






        //Productos
        [HttpPost]
        public JsonResult MtdGuardarProducto(ClProductoE objProducto)
        {
            string mensaje = string.Empty;
            int result = new ClProductoL().MtdGuardarProducto();

            return Json(new { data = result, mensaje = mensaje });
        }








    }
}
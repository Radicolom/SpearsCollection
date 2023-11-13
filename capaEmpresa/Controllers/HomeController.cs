using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace capaEmpresa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult MtdListarUsuario()
        {
            List<ClUsuarioE> objLista = new List<ClUsuarioE>();
            objLista = new ClUsuarioL().MtdListar();

            return Json(new { data = objLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult MtdListarRol()
        {
            List<ClRolE> objLista = new List<ClRolE>();
            objLista = new ClRolL().MtdListar();

            return Json(new { data = objLista }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult MtdListarCiudad()
        {
            List<ClCiudadE> objLista = new List<ClCiudadE>();
            objLista = new ClCiudadL().MtdListar();

            return Json(new { data = objLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult MtdGuardarUsuario(ClUsuarioE objUsuario)
        {
            string mensaje = string.Empty;
            int result = new ClUsuarioL().MtdGuardar(objUsuario, out mensaje);
            return Json(new { data = result, mensaje = mensaje });
        }

        [HttpPost]
        public JsonResult MtdEliminarUsuario(ClUsuarioE objUsuario)
        {
            string mensaje = string.Empty;
            int result = new ClUsuarioL().MtdEliminar(objUsuario, out mensaje);
            return Json(new { data = result, mensaje = mensaje });
        }

        [HttpPost]
        public JsonResult MtdGuardarRol(ClRolE objRol)
        {
            string mensaje = string.Empty;
            int result = new ClRolL().MtdGuardar(objRol, out mensaje);
            return Json(new { data = result, mensaje = mensaje });

        }

        [HttpPost]
        public JsonResult MtdEliminarRol(ClRolE objRol)
        {
            string mensaje = string.Empty;
            int result = new ClRolL().MtdEliminar(objRol, out mensaje);
            return Json(new { data = result, mensaje = mensaje });

        }





    }
}
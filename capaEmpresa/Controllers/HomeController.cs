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

        public JsonResult MtdListarUsuario()
        {
            List<ClUsuarioE> objLista = new List<ClUsuarioE>();
            objLista = new ClUsuarioL().MtdListar();

            return Json(new { data = objLista }, JsonRequestBehavior.AllowGet);
            //return Json(objLista,JsonRequestBehavior.AllowGet);
        }

        public JsonResult MtdListarRol()
        {
            List<ClRolE> objLista = new List<ClRolE>();
            objLista = new ClRolL().MtdListar();

            return Json(new { data = objLista}, JsonRequestBehavior.AllowGet);
        }
        
    }
}
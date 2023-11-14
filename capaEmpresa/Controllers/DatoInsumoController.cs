﻿using CapaEntidad;
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
        


        [HttpGet]
        public JsonResult MtdListarProveedor()
        {
            List<ClUsuarioE> objLista = new List<ClUsuarioE>();
            objLista = new ClProvedorL().MtdListar();

            return Json(new { data = objLista }, JsonRequestBehavior.AllowGet);
        }

    }
}
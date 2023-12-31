﻿using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace capaEmpresa.Models
{
    public class ClCorteL
    {
        private ClCortesD objCorte = new ClCortesD();
        private string emailY = "";

        public List<ClCorteE> MtdListar()
        {
            string mensaje = string.Empty;
            List<ClCorteE> lista = objCorte.MtdLista(out mensaje);
            if (!string.IsNullOrEmpty(mensaje))
            {
                ClRecursosL.MtdEnvioEmail(emailY, mensaje);
            }
            return lista;
        }

    }
}
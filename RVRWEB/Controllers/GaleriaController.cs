﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RVRWEB.Controllers
{
    public class GaleriaController : Controller
    {
        // GET: Galeria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JogoDaVelha()
        {
            return View();
        }
    }
}
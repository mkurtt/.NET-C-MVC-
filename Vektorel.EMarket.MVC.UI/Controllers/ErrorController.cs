﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vektorel.EMarket.MVC.UI.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {

            //Loglama
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult Forbidden()
        {
            //Loglama
            return View();
        }
    }
}
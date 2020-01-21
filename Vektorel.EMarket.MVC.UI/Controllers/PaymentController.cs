using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vektorel.EMarket.MVC.UI.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Basket()
        {
            return View(viewName: "~/Views/Payment/detailed.cshtml");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.EMarket.MVC.UI.Manage.Filters;

namespace Vektorel.EMarket.MVC.UI.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandlerAttribute { View = "~/Views/Error/internalservererror.cshtml" });
            filters.Add(new CacheFilter());
        }
    }
}
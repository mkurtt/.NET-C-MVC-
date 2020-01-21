using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vektorel.EMarket.MVC.UI.Manage.Filters
{
    public class CustomHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                //filterContext.Exception
                //Loglama
                if (!filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {

                    filterContext.Result = new ViewResult{
                         ViewName  = View,
                         //ViewBag.Message = filterContext.Exception.Message;
                         ViewData = new ViewDataDictionary(new HandleErrorInfo(filterContext.Exception,
                             filterContext.RouteData.Values["controller"].ToString(),
                             filterContext.RouteData.Values["action"].ToString()))
                    };
                }
                else
                {
                    var responseData = new Dictionary<string, object>();
                    responseData.Add("status", false);
                    responseData.Add("exception", filterContext.Exception);

                    filterContext.Result = new JsonResult
                    {
                         JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                         Data = responseData
                    };
                }
                filterContext.ExceptionHandled = true;

            }
            //base.OnException(filterContext);
        }
    }
}
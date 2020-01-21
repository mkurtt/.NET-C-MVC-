using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vektorel.EMarket.AdminPanel.UI.Manage.Sessions;

namespace Vektorel.EMarket.AdminPanel.UI.Manage.Filters
{
    public class AuthenticationAttribute :  FilterAttribute,IActionFilter
    {
        public bool Authenticatble { get; set; }
        public AuthenticationAttribute(bool authenticatable)
        {
            Authenticatble = authenticatable;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Authenticatble)
            {
                if (UserSessions.CurrentUser==null)
                {
                    var route = new RouteValueDictionary();
                    route.Add("action","Login");
                    route.Add("controller","Account");
                    filterContext.Result = new RedirectToRouteResult(route);
                }
            }

        }
    }
}
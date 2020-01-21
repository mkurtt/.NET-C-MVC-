using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vektorel.EMarket.AdminPanel.UI.Manage.Sessions;
using Vektorel.EMarket.Datacore.Infrastructure;
using Vektorel.EMarket.Domain.Model;

namespace Vektorel.EMarket.AdminPanel.UI.Manage.Filters
{
    public class AuthorizationAttribute : FilterAttribute, IActionFilter
    {
        public string ModuleName { get; set; }
        public string RouteOrPath { get; set; }
        public AuthorizationAttribute(string moduleName,string routeorpath)
        {
            ModuleName = moduleName;
            RouteOrPath = routeorpath;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool is_authorized = false;
            var kernel = new StandardKernel(new InstanceModule());
            var roles = kernel.Get<IUserRepository>().GetUserRoles(UserSessions.CurrentUser.Id);
            if (roles.State== MAA.Basecore.Model.Enums.BusinessResultType.Success)
            {
                foreach (var role in roles.Result)
                {
                    foreach (var module in role.Modules)
                    {
                        if (module.Name==this.ModuleName)
                        {
                            is_authorized = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                //Log

                var route = new RouteValueDictionary();
                route.Add("action", "");
                route.Add("controller", "");
                route.Add("message", "The request is not authorizable. Reason: Error.");
                filterContext.Result = new RedirectToRouteResult(route);
            }
            if (!is_authorized)
            {
                var route = new RouteValueDictionary();
                route.Add("action","");
                route.Add("controller","");
                route.Add("message", "You are not authorized.");
                filterContext.Result = new RedirectToRouteResult(route);
            }
        }
    }
}
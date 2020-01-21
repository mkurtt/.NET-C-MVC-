using MAA.Basecore.Model.Enums;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.EMarket.Datacore.Infrastructure;
using Vektorel.EMarket.MVC.UI.Manage.Cache;

namespace Vektorel.EMarket.MVC.UI.Manage.Filters
{
    public class CacheFilter : FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (ProductCaching.CachedProducts == null)
            {
                var result = CommonProvider.InstanceKernel.Get<IProductRepository>().FindList(p => p.IsActive && !p.IsDeleted);
                if (result.State == BusinessResultType.Success)
                {
                    ProductCaching.CachedProducts = result.Result;
                }
            }

            if (CategoryCaching.CachedCategoryGroups==null)
            {
                var result = CommonProvider.InstanceKernel.Get<ICategoryRepository>().GetTopTenCategoryGroupsWithCategory();
                if (result.State==BusinessResultType.Success)
                {
                    CategoryCaching.CachedCategoryGroups = result.Result;
                }
            }



        }
    }
}
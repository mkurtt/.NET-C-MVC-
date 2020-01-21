using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vektorel.EMarket.Domain.Model.EMarketDb;
using ch = System.Web.Caching;

namespace Vektorel.EMarket.MVC.UI.Manage.Cache
{
    public class CategoryCaching
    {
        public static List<CategoryGroup> CachedCategoryGroups
        {
            get
            {
                if (HttpContext.Current.Cache["CachedCategoryGroups"] == null)
                {
                    return null;
                }
                return HttpContext.Current.Cache["CachedCategoryGroups"] as List<CategoryGroup>;
            }
            set
            {
                HttpContext.Current.Cache.Insert("CachedCategoryGroups", value, null, DateTime.Now.AddHours(24), ch.Cache.NoSlidingExpiration, ch.CacheItemPriority.High, OnRemoveCallBack);
            }
        }

        private static void OnRemoveCallBack(string key, object data, ch.CacheItemRemovedReason reason)
        {

            switch (reason)
            {
                case System.Web.Caching.CacheItemRemovedReason.DependencyChanged:
                    //Log
                    break;
                case System.Web.Caching.CacheItemRemovedReason.Expired:

                    //Renew
                    break;
                case System.Web.Caching.CacheItemRemovedReason.Removed:
                    //Log 
                    break;
                case System.Web.Caching.CacheItemRemovedReason.Underused:

                    break;
            }

        }
    }
}
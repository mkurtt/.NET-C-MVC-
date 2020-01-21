using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vektorel.EMarket.MVC.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute("rtLogin", "login", new { controller = "Account", action = "Login" });
            routes.MapRoute("rtRegister", "register", new { controller = "Account", action = "Register" });
            routes.MapRoute("rtIndex", "index", new { controller = "Home", action = "Index" });
            routes.MapRoute("rtDefault", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("rtLogout", "logout", new { controller = "AsyncAccount", action = "Logout" });
            routes.MapRoute("rtChangeCate", "filter/bycategory/{categoryid}", new { controller = "Home", action = "ChangeProductsByCategoryId" });



           //Product
            routes.MapRoute("rtP_featuredProducts", "partial/product/featured", new { action = "RenderFeaturedProducts", controller = "Product" });
            routes.MapRoute("rtP_latestProducts", "partial/product/latest", new { action = "RenderLatestProducts", controller = "Product" });
            routes.MapRoute("rtP_productDetail", "product/detail/{productid}", new { action = "ProductDetail", controller = "Product" });
            routes.MapRoute("rtP_addtobasket", "product/addtobasket/", new { action = "AddToBasket", controller = "Product" });
            routes.MapRoute("rtP_removefrombasket", "product/removefrombasket/", new { action = "RemoveFromBasket", controller = "Product" });


            //Payment
            routes.MapRoute("rtPy_basketdetailed", "basket/detail", new { action = "Basket", controller = "Payment" });

            //Category
            routes.MapRoute("rtP_sidebar", "partial/category/sidebar", new { action = "LoadCategories", controller = "Home" });

            //Errors
           routes.MapRoute("rtErrNotFound", "notfound", new { controller = "Error", action = "NotFound" });
           routes.MapRoute("rtErrInternal", "internalserver", new { controller = "Error", action = "InternalServerError" });
           routes.MapRoute("rtErrForbidden", "forbidden", new { controller = "Error", action = "Forbidden" });


            //async
           routes.MapRoute("asyncLogin", "async/login", new { controller = "AsyncAccount", action = "Login" });
            
        }
    }
}


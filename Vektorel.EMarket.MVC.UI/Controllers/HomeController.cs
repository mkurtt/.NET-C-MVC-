using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.EMarket.MVC.UI.Manage.Cache;
using Vektorel.EMarket.MVC.UI.Manage.Filters;
using Vektorel.EMarket.MVC.UI.Manage.Sessions;
using Vektorel.EMarket.MVC.UI.Models.ViewModels;

namespace Vektorel.EMarket.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [CustomHandler(View="~/Views/Error/internalservererror.cshtml")]
        public ActionResult Index()
        {
            IndexViewModel model = null;
            if (ProductSessions.SelectedCategoryId==0)
            {
                model = new IndexViewModel { TotalProductCount = ProductCaching.CachedProducts.Count() };
            }
            else
            {
                model = new IndexViewModel { TotalProductCount = ProductCaching.CachedProducts.Where(p=>p.CategoryId==ProductSessions.SelectedCategoryId).Count() };
            }
            return View(model);
        }


        public PartialViewResult LoadCategories()
        {
            return PartialView("~/Views/Shared/Partials/sidebar.cshtml", new SideBarViewModel { Groups = CategoryCaching.CachedCategoryGroups });
        }


        public ActionResult ChangeProductsByCategoryId(int categoryid)
        {
            ProductSessions.SelectedCategoryId = categoryid;
            return RedirectToAction("Index");
        }
    }
}
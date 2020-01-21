using MAA.Basecore.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.EMarket.Datacore.Infrastructure;
using Vektorel.EMarket.Domain.Model.EMarketDb;
using Vektorel.EMarket.MVC.UI.Manage.Cache;
using Vektorel.EMarket.MVC.UI.Manage.Sessions;
using Vektorel.EMarket.MVC.UI.Models.ViewModels;

namespace Vektorel.EMarket.MVC.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository pRepository;
        public ProductController(IProductRepository pRepo)
        {
            pRepository = pRepo;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult RenderLatestProducts(int startindex = 1, int itemcount = 6)
        {
            List<Product> products = null;
            if (ProductSessions.SelectedCategoryId == 0)
            {
                products = ProductCaching.CachedProducts.Skip(itemcount * (startindex - 1)).Take(itemcount).ToList();
            }
            else
            {
                products = ProductCaching.CachedProducts.Where(p => p.CategoryId == ProductSessions.SelectedCategoryId).Skip(itemcount * (startindex - 1)).Take(itemcount).ToList();
            }

            return PartialView("~/Views/Product/Partials/LatestProducts.cshtml", products);
        }

        public PartialViewResult RenderFeaturedProducts()
        {

            var result = pRepository.Get16ProductsWithMostDiscRate();

            return PartialView("~/Views/Product/Partials/FeaturedProducts.cshtml", result.Result);
        }


        public ActionResult ProductDetail(string productid)
        {
            ProductDetailViewModel model = null;
            Guid p_id = Guid.Parse(productid.Split('_')[1]);
            var result = pRepository.Get(p => p.Id == p_id);
            if (result.State == BusinessResultType.Success)
            {
                model = new ProductDetailViewModel { Product = result.Result, RelatedProducts = pRepository.GetProductsByCategoryId(result.Result.CategoryId).Result.Take(6).ToList() };
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult AddToBasket(Guid productid, int quantity)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            var result = pRepository.Get(p => p.Id == productid);
            if (result.State == BusinessResultType.Success)
            {
                decimal total = 0;
                BasketHelper.Add(result.Result, quantity);
                foreach (var item in BasketHelper.ProductsInBasket)
                {
                    total += (item.Key.UnitPrice * item.Value);
                }
                response.Add("status", true);
                response.Add("message", "");
                response.Add("total", total);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", result.Message);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult RemoveFromBasket(Guid productid, int quantity)
        {
            Dictionary<string, object> response = new Dictionary<string, object>();
            var result = pRepository.Get(p => p.Id == productid);
            if (result.State == BusinessResultType.Success)
            {
                decimal total = 0;
                BasketHelper.Remove(result.Result, quantity);
                foreach (var item in BasketHelper.ProductsInBasket)
                {
                    total += (item.Key.UnitPrice * item.Value);
                }
                response.Add("status", true);
                response.Add("message", "");
                response.Add("total", total);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", result.Message);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}
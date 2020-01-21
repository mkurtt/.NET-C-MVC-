using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vektorel.EMarket.AdminPanel.UI.Manage.Filters;
using Vektorel.EMarket.AdminPanel.UI.Manage.Sessions;
using Vektorel.EMarket.AdminPanel.UI.Models.ViewModels;
using Vektorel.EMarket.Datacore.Infrastructure;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.AdminPanel.UI.Controllers
{

    //js-grid.com
    //[Authorization("ProductModule", "")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        public ProductController(IProductRepository pRepo, ICategoryRepository categoryRepo)
        {
            productRepository = pRepo;
            categoryRepository = categoryRepo;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [Authorization("New Product", "/Product/NewProduct")]
        [HttpGet]
        public ActionResult NewProduct()
        {
            var result = categoryRepository.GetList();
            List<Category> categories = new List<Category>();
            if (result.State == MAA.Basecore.Model.Enums.BusinessResultType.Success)
            {
                categories = result.Result;
            }
            return View(model: new NewProductViewModel { Categories = categories });
        }

        [Authorization("New Product", "/Product/NewProduct")]
        [HttpPost]
        public ActionResult NewProduct([Bind(Prefix="Product")]Product model)
        {
            model.UserId = UserSessions.CurrentUser.Id;
            var result = productRepository.Insert(model);
            if (result.State == MAA.Basecore.Model.Enums.BusinessResultType.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                //Log
            }
            return View();
        }


        public JsonResult GetProducts()
        {
            Dictionary<string, object> reqResult = new Dictionary<string, object>();
            var result = productRepository.GetList();
            if (result.State == MAA.Basecore.Model.Enums.BusinessResultType.Success)
            {
                reqResult.Add("status", true);
                reqResult.Add("message", "");
                reqResult.Add("data", result.Result);
            }
            else
            {
                reqResult.Add("status", false);
                reqResult.Add("message", result.Message);
                reqResult.Add("data", null);
            }
            return Json(reqResult, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(Product model)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            //Silme işlemi
            result.Add("status", true);
            result.Add("message", "Silindi");
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}
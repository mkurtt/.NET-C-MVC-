using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vektorel.EMarket.Datacore.Infrastructure;
using Vektorel.EMarket.WebApi.Models;
using MAA.Basecore.Model.Enums;
using MAA.Basecore.Helpers.Common;

namespace Vektorel.EMarket.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepo)
        {
            productRepository = productRepo;
        }

        //E7F2CA17-6130-4789-BA5C-4CCC45709A7B

        //[Route("api/getdata")]
        [HttpPost]
        public Dictionary<string, object> GetProduct(string prodid)
        {
            var result = new Dictionary<string, object>();
            try
            {
                Guid productid = Guid.Parse(prodid);
                var productResult = productRepository.Get(p => p.Id == productid);
                switch (productResult.State)
                {
                    case BusinessResultType.NotSet:


                        break;
                    case BusinessResultType.Success:
                        result.Add("status", true);
                        result.Add("data", productResult.Result);
                        result.Add("code", 40);
                        result.Add("message", "");
                        break;
                    case BusinessResultType.Error:
                        result.Add("status", false);
                        result.Add("data", productResult.Result);
                        result.Add("code", 41);
                        result.Add("message", "Veri kaynağında bir hata oluştu.");
                        //Log işlemi
                        //productResult.Message
                        break;
                    case BusinessResultType.Warning:
                        break;
                    case BusinessResultType.Info:
                        break;
                }
            }
            catch (Exception ex)
            {
                result.Add("status", false);
                result.Add("data", null);
                result.Add("code", 45);
                result.Add("message", ex.GetOriginalException().Message);
            }
            return result;
        }

    }
}

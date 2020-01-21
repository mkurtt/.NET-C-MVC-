using MAA.Basecore.Helpers.Common;
using MAA.Basecore.Model.Enums;
using MAA.Basecore.Model.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Infrastructure
{
    public partial class ProductRepository
    {
        public BusinessResult<List<Product>> GetProductsByCategoryId(int categoryid)
        {
            BusinessResult<List<Product>> result = null;
            try
            {
                var productResult = Context.Products.Where(x => x.CategoryId == categoryid).ToList();
                if (productResult.Any())
                {
                    result = new BusinessResult<List<Product>>(productResult);
                }
                else
                {
                    result = new BusinessResult<List<Product>>(null, "Nothing in the list", BusinessResultType.Info);
                }

            }
            catch (Exception ex)
            {
                result = new BusinessResult<List<Product>>(null, ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }
    }
}

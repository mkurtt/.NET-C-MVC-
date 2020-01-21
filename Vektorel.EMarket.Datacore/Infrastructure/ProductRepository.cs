using MAA.Basecore.Data.EntityFramework.Persistence;
using MAA.Basecore.Helpers.Common;
using MAA.Basecore.Model.Enums;
using MAA.Basecore.Model.ResultTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Datacore.Context;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Infrastructure
{
    public interface IProductRepository : IRepository<Product>
    {
        BusinessResult<List<Product>> GetNextActiveProducts(int count, int startid);

        BusinessResult<List<Product>> GetProductsByCategoryId(int categoryid);

        BusinessResult<List<Product>> Get16ProductsWithMostDiscRate();

        BusinessResult<List<Product>> GetNewestProducts();

    }
    public partial class ProductRepository : Repository<EMarketDbContext,Product>, IProductRepository
    {

        public ProductRepository(EMarketDbContext ctx) : base(ctx)
        {

        }
        public BusinessResult<List<Product>> GetNextActiveProducts(int count, int skip)
        {
            BusinessResult<List<Product>> result = null;
            try
            {
                #region SqlQuery
                //string query = string.Format("Select top @count* {0} where Id>@startid and IsActive=1 and IsDeleted=0",DbConstants.Products.SchemaWithName);
                //var parameters = new[]
                //{
                //    new SqlParameter("@count",count),
                //    new SqlParameter("@startid",startid)
                //};

                #endregion

                var queryResult = Context.Products.Where(x => x.IsActive && !x.IsDeleted).OrderBy(x=>x.CreatedAt).Skip(skip).Take(count).ToList();
                if (queryResult.Any())
                {
                    result = new BusinessResult<List<Product>>(queryResult);
                }
                else
                {
                    result = new BusinessResult<List<Product>>(null, "No record in the list", BusinessResultType.Info);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<List<Product>>(null, ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<List<Product>> Get16ProductsWithMostDiscRate()
        {
            BusinessResult<List<Product>> result = null;
            try
            {
                var queryResult = Context.Products.Where(x=>x.IsActive&&!x.IsDeleted).OrderByDescending(x => x.DiscountRate).Take(16).ToList();

                if (queryResult.Any())
                {
                    result = new BusinessResult<List<Product>>(queryResult);
                }
                else
                {
                    result = new BusinessResult<List<Product>>(null, "No record in the list", BusinessResultType.Info);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<List<Product>>(null, ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }


        public BusinessResult<List<Product>> GetNewestProducts()
        {
            BusinessResult<List<Product>> result = null;
            try
            {
                var queryResult = Context.Products.Where(x => x.IsActive && !x.IsDeleted).OrderByDescending(x => x.CreatedAt).Take(4).ToList();

                if (queryResult.Any())
                {
                    result = new BusinessResult<List<Product>>(queryResult);
                }
                else
                {
                    result = new BusinessResult<List<Product>>(null, "No record in the list", BusinessResultType.Info);
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

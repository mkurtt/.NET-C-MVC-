using MAA.Basecore.Data.EntityFramework.Persistence;
using MAA.Basecore.Helpers.Common;
using MAA.Basecore.Model.Enums;
using MAA.Basecore.Model.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Datacore.Context;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Infrastructure
{
    public interface ICategoryRepository : IRepository<Category>
    {
        BusinessResult<List<CategoryGroup>> GetGroupsWithCategory();

        BusinessResult<List<CategoryGroup>> GetTopTenCategoryGroupsWithCategory();

        BusinessResult<List<Category>> GetTopProductCategories(int categorycount);
    }
    public partial class CategoryRepository : Repository<EMarketDbContext, Category>, ICategoryRepository
    {
        public CategoryRepository(EMarketDbContext ctx) : base(ctx)
        {
        }

        public BusinessResult<List<CategoryGroup>> GetGroupsWithCategory()
        {
            BusinessResult<List<CategoryGroup>> result = null;
            try
            {
                var queryResult = Context.CategoryGroups.Include("Categories").ToList();
                if (queryResult.Any())
                {
                    result = new BusinessResult<List<CategoryGroup>>(queryResult);
                }
                else
                {
                    result = new BusinessResult<List<CategoryGroup>>(null, "There is not any categories", BusinessResultType.Info);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<List<CategoryGroup>>(null, ex.GetOriginalException().Message, BusinessResultType.Warning);
            }
            return result;
        }

        public BusinessResult<List<CategoryGroup>> GetTopTenCategoryGroupsWithCategory()
        {
            BusinessResult<List<CategoryGroup>> result = null;
            try
            {
                var queryResult = Context.CategoryGroups.Include("Categories").Take(10).ToList();
                if (queryResult.Any())
                {
                    result = new BusinessResult<List<CategoryGroup>>(queryResult);
                }
                else
                {
                    result = new BusinessResult<List<CategoryGroup>>(null, "There is not any category groups", BusinessResultType.Info);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<List<CategoryGroup>>(null, ex.GetOriginalException().Message, BusinessResultType.Warning);
            }
            return result;
        }

        
    }
}

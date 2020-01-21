using MAA.Basecore.Helpers.Common;
using MAA.Basecore.Model.Enums;
using MAA.Basecore.Model.ResultTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Infrastructure
{
    public partial class CategoryRepository 
    {
        public BusinessResult<List<Category>> GetTopProductCategories(int categorycount)
        {
            BusinessResult<List<Category>> result = null;
            try
            {
                var query = string.Format("select * from {0} where Id in (select top @count CategoryId from {1} group by CategoryId order by count(*) desc)",DbConstants.Categories.SchemaWithName,DbConstants.Products.SchemaWithName);
                var queryResult = Context.Categories.SqlQuery(query, new SqlParameter("@count", categorycount)).ToList();
                if (queryResult.Any())
                {

                    foreach (var category in queryResult)
                    {
                        category.Group = Context.CategoryGroups.SingleOrDefault(cg=>cg.Id==category.GroupId);
                    }
                    result = new BusinessResult<List<Category>>(queryResult);
                }
                else
                {
                    result = new BusinessResult<List<Category>>(null, "There is not any categories", BusinessResultType.Info);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<List<Category>>(null, ex.GetOriginalException().Message, BusinessResultType.Warning);
            }
            return result;
        }
    }
}

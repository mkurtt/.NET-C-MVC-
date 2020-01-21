using MAA.Basecore.Data.EntityFramework.Persistence;
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
using MAA.Basecore.Helpers.Common;

namespace Vektorel.EMarket.Datacore.Infrastructure
{
    public interface IRoleRepository : IRepository<Role>
    {
        BusinessResult<List<Role>> GetRolesWithModules();
    }

    public class RoleRepository : Repository<EMarketDbContext, Role>, IRoleRepository
    {
        public RoleRepository(EMarketDbContext ctx) : base(ctx)
        {
        }

        public BusinessResult<List<Role>> GetRolesWithModules()
        {
            BusinessResult<List<Role>> result = null;
            try
            {
                var roles = Context.Roles.Where(r => r.IsActive && !r.IsDeleted).ToList();
                if (roles.Any())
                {
                    foreach (var role in roles)
                    {
                        string modulecommand = string.Format("Select * from {0} where IsActive=1 and Id In(Select ModuleId from {1} where RoleId=@roleid)", DbConstants.Modules.SchemaWithName, DbConstants.RoleModules.SchemaWithName);

                        role.Modules = Context.Modules.SqlQuery(modulecommand, new SqlParameter("@roleid", role.Id)).ToList();

                    }
                    result = new BusinessResult<List<Role>>(roles);
                }
                else
                {
                    result = new BusinessResult<List<Role>>(null, "No Records", BusinessResultType.Warning);
                }
            }
            catch (Exception ex)
            {

                result = new BusinessResult<List<Role>>(null, ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }
    }
}

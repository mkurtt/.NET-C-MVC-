using MAA.Basecore.Data.EntityFramework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Datacore.Context;
using Vektorel.EMarket.Domain.Model.EMarketDb;
using Vektorel.EMarket.Domain.ResultTypes;
using MAA.Basecore.Helpers.Common;
using MAA.Basecore.Model.Enums;
using Vektorel.EMarket.Domain.Constants;
using MAA.Basecore.Model.ResultTypes;
using System.Data.SqlClient;

namespace Vektorel.EMarket.Datacore.Infrastructure
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        UserResult Login(string email, string password);

        BusinessResult<Customer> CreateWebsiteUser(ApplicationUser customer);

        BusinessResult<List<Role>> GetUserRoles(int userid);
    }


    public partial class UserRepository : Repository<EMarketDbContext, ApplicationUser>, IUserRepository
    {
        public UserRepository(EMarketDbContext ctx)
            : base(ctx)
        {

        }



        public UserResult Login(string email, string password)
        {
            UserResult result = null;
            try
            {
                password = password.GetMD5Hash();
                var user = Context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
                if (user == null)
                {
                    result = new UserResult(UserResultType.NotFound, null, "Böyle bir kullanıcı yok", BusinessResultType.Info);
                }
                else
                {
                    if (!user.IsActive)
                    {
                        result = new UserResult(UserResultType.Blocked, user, "Engellenmiş kullanıcı", BusinessResultType.Info);
                    }
                    else if (user.IsDeleted)
                    {
                        result = new UserResult(UserResultType.NotFound, user, "Bu kullanıcı silinmiş", BusinessResultType.Info);
                    }
                    else
                    {
                        result = new UserResult(UserResultType.Authenticated, user, "", BusinessResultType.Success);
                    }
                }

            }
            catch (Exception ex)
            {
                result = new UserResult(UserResultType.UnAuthorized, null, "Hata:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }





        public BusinessResult<List<Role>> GetUserRoles(int userid)
        {
            BusinessResult<List<Role>> result = null;
            try
            {
                string command = string.Format("Select * from {0} where IsActive=1 and Id IN(Select RoleId from {1} where UserId=@userid)",DbConstants.Roles.SchemaWithName,DbConstants.UserRoles.SchemaWithName);
                var roles = Context.Roles.SqlQuery(command,
                    new SqlParameter("@userid",userid)).ToList();
                if (roles.Any())
                {
                    foreach (var role in roles)
                    {
                        string modulecommand = string.Format("Select * from {0} where IsActive=1 and Id In(Select ModuleId from {1} where RoleId=@roleid)",DbConstants.Modules.SchemaWithName,DbConstants.RoleModules.SchemaWithName);

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

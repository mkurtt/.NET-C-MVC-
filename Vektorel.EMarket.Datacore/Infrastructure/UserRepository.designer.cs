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
    public partial class UserRepository
    {
        public BusinessResult<Customer> CreateWebsiteUser(ApplicationUser user)
        {
            BusinessResult<Customer> result = null;
            using (var trns = Context.Database.BeginTransaction())
            {
                try
                {
                    if (!Context.Users.Any(x => x.Email == user.Email))
                    {
                        user.Password = user.Password.GetMD5Hash();
                        var u = Context.Users.Add(user);
                        if (Context.SaveChanges() > 0)
                        {
                            var full = user.FullName.Split(' ').ToList();
                            var surname = full.Take(full.Count - 1).Aggregate((c, n) => c + " " + n).Trim();
                            var customer = Context.Customers.Add(new Customer
                            {
                                Name = full.Last(),
                                Surname = surname,
                                UserId = u.Id
                            });
                            if (Context.SaveChanges() > 0)
                            {
                                var role = Context.Roles.SingleOrDefault(x => x.Name == "Customer");
                                if (role != null)
                                {

                                    int exRes = Context.Database.ExecuteSqlCommand(string.Format("Insert into {0} (UserId,RoleId) values (@userid,@roleid)", DbConstants.UserRoles.SchemaWithName),
                                         new SqlParameter("@userid", u.Id),
                                         new SqlParameter("@roleid", role.Id));
                                    Context.SaveChanges();
                                    if (exRes > 0)
                                    {
                                        trns.Commit();
                                        result = new BusinessResult<Customer>(customer);
                                    }
                                    else
                                    {

                                        result = new BusinessResult<Customer>(customer, "Error while adding a role.", BusinessResultType.Info);
                                    }
                                }
                                else
                                {
                                    result = new BusinessResult<Customer>(customer, "There was not a matching role for Customer.", BusinessResultType.Info);
                                }
                            }
                            else
                            {
                                result = new BusinessResult<Customer>(customer, "Error while adding a Customer.", BusinessResultType.Warning);
                            }
                        }
                    }
                    else
                    {
                        result = new BusinessResult<Customer>(null, "This email already been taken", BusinessResultType.Warning);
                    }

                }
                catch (Exception ex)
                {
                    trns.Rollback();
                    result = new BusinessResult<Customer>(null, ex.GetOriginalException().Message, BusinessResultType.Error);
                }
            }
            return result;
        }
    }
}

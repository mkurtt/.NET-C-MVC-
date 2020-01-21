namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vektorel.EMarket.Datacore.Context;
    using Vektorel.EMarket.Domain.Model.EMarketDb;
    using MAA.Basecore.Helpers.Common;
    using Vektorel.EMarket.Domain.Constants;
    using System.Data.SqlClient;

    internal sealed class Configuration : DbMigrationsConfiguration<Vektorel.EMarket.Datacore.Context.EMarketDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EMarketDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var admin = new ApplicationUser
            {
                Password = "admin2019".GetMD5Hash(),
                Email = "admin@email.com",
                FullName = "Admin User",
                PicturePath = "default.jpg"
            };
            context.Users.AddOrUpdate(x => x.Email, admin);
            context.SaveChanges();
             context.Roles.AddOrUpdate(x=>x.Name,new Role { Name = "Customer" });
            var adminRole = new Role { Name = "Admin" };
            context.Roles.AddOrUpdate(x => x.Name,adminRole);
            context.SaveChanges();
            context.Database.ExecuteSqlCommand(string.Format("Insert into {0}.{1} (UserId,RoleId) values (@userid,@roleid)", DbConstants.UserRoles.Schema, DbConstants.UserRoles.Name),
                                         new SqlParameter("@userid", admin.Id),
                                         new SqlParameter("@roleid", adminRole.Id));



            context.SaveChanges();
        }
    }
}

using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vektorel.EMarket.Datacore.Infrastructure;

namespace Vektorel.EMarket.AdminPanel.UI
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override Ninject.IKernel CreateKernel()
        {
            return new StandardKernel(new InstanceModule());
        }
    }

    public class InstanceModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            Bind<IRoleRepository>().To<RoleRepository>().InSingletonScope();
            Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            Bind<ICategoryRepository>().To<CategoryRepository>().InSingletonScope();
        }
    }
}

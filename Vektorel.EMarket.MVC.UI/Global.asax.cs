using Ninject;
using Ninject.Modules;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vektorel.EMarket.Datacore.Infrastructure;
using FluentValidation;
using FluentValidation.Mvc;
using Vektorel.EMarket.MVC.UI.Models.Validators;
using Vektorel.EMarket.MVC.UI.Models.ViewModels;
using Vektorel.EMarket.MVC.UI.App_Start;
using System.Web.Optimization;
using Vektorel.EMarket.MVC.UI.Manage;

namespace Vektorel.EMarket.MVC.UI
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);


            //BundleConfig Eklendi - RouteConfig ile aynı mekanizma - BunldeConfig için Microsoft.AspNet.Web.Optimization nuggetten yükle
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new Factory(new ValidationModule());
                provider.AddImplicitRequiredValidator = false;
            });

        }

        protected override IKernel CreateKernel()
        {
            CommonProvider.InstanceKernel = new StandardKernel(new InstanceModule());
            return  CommonProvider.InstanceKernel;
        }
    }

    public class InstanceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            Bind<ICustomerRepository>().To<CustomerRepository>().InSingletonScope();
            Bind<IOrderRepository>().To<OrderRepository>().InSingletonScope();
            Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            Bind<IRoleRepository>().To<RoleRepository>().InSingletonScope();
            Bind<ICategoryRepository>().To<CategoryRepository>().InSingletonScope();
            
        }
    }

    public class ValidationModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IValidator<LoginModel>>().To<LoginValidator>().InSingletonScope();
            Bind<IValidator<RegisterModel>>().To<RegisterValidator>().InSingletonScope();
        }
    }
}

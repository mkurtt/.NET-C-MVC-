using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Datacore.Infrastructure;

namespace Vektorel.EMarketTestForm.UI
{
    public class InstanceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            //Bind(typeof(UserRepository)).To<UserRepository>().InSingletonScope();
        }
    }
}

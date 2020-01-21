using FluentValidation;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vektorel.EMarket.MVC.UI.Manage;

namespace Vektorel.EMarket.MVC.UI.Models.Validators
{
    public class Factory : ValidatorFactoryBase
    {
        private readonly IKernel kernel;
        public Factory(INinjectModule module)
        {
            kernel = new StandardKernel(module);
            CommonProvider.ValidationKernel = kernel;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return validatorType == null ? null : (IValidator)kernel.Get(validatorType);
        }
    }
}
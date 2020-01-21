using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ch = System.Web.Caching;

namespace Vektorel.EMarket.MVC.UI.Manage
{
    public class CommonProvider
    {
        public static IKernel InstanceKernel
        {
            get { return HttpContext.Current.Cache["InstanceKernel"] as IKernel; }
            set { HttpContext.Current.Cache.Insert("InstanceKernel", value); }
        }

        public static IKernel ValidationKernel
        {
            get { return HttpContext.Current.Cache["ValidationKernel"] as IKernel; }
            set { HttpContext.Current.Cache.Insert("ValidationKernel", value); }
        }
    }
}
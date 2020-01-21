using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.MVC.UI.Manage.Sessions
{
    public class UserSessions
    {
        public static ApplicationUser CurrentUser
        {
            set { HttpContext.Current.Session.Add("Faruk", value); }
            get { return HttpContext.Current.Session["Faruk"] as ApplicationUser; }
        }

        public static ApplicationUser CurrentCustomer
        {
            set { HttpContext.Current.Session.Add("CurrentCustomer", value); }
            get { return HttpContext.Current.Session["CurrentCustomer"] as ApplicationUser; }
        }

    }
}
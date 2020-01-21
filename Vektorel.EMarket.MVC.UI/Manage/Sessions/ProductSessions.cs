using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vektorel.EMarket.MVC.UI.Manage.Sessions
{
    public class ProductSessions
    {
        public static int SelectedCategoryId
        {
            get
            {
                var session = HttpContext.Current.Session["SelectedCategoryId"];
                if (session==null)
                {
                    HttpContext.Current.Session.Add("SelectedCategoryId", 0);
                }
                return (int)HttpContext.Current.Session["SelectedCategoryId"];
            }
            set
            {
                HttpContext.Current.Session.Add("SelectedCategoryId", value);
            }
        }
    }
}
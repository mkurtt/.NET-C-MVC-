using System.Web;
using System.Web.Mvc;
using Vektorel.EMarket.AdminPanel.UI.Manage.Filters;

namespace Vektorel.EMarket.AdminPanel.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthenticationAttribute(true));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vektorel.EMarket.MVC.UI.Models.ViewModels
{
    public class BaseViewModel
    {
        public LoginModel LoginUser { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.MVC.UI.Models.ViewModels
{
    public class LoginModel
    {

        //public ApplicationUser User { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
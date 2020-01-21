using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vektorel.EMarket.MVC.UI.Models.ViewModels
{
    public class RegisterModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
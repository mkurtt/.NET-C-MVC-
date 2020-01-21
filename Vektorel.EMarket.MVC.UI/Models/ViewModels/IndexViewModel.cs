using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.MVC.UI.Models.ViewModels
{
    public class IndexViewModel : BaseViewModel
    {
        public int TotalProductCount { get; set; }
    }
}
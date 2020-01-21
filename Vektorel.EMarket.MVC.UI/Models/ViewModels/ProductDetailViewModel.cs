using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.MVC.UI.Models.ViewModels
{
    public class ProductDetailViewModel : BaseViewModel
    {
        public ProductDetailViewModel()
        {
            StockSize = DateTime.Now.Hour > 12 ? 1 : 5;
        }
        public Product Product { get; set; }

        public int StockSize { get; set; }

        public List<Product> RelatedProducts { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.AdminPanel.UI.Models.ViewModels
{
    public class NewProductViewModel
    {
        public NewProductViewModel()
        {
            Product = new Product();
        }
        public List<Category> Categories { get; set; }

        public Product Product { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.MVC.UI.Manage.Sessions
{
    public static class BasketHelper
    {
        public static Dictionary<Product, int> ProductsInBasket
        {
            get
            {
                var session = HttpContext.Current.Session["Basket"];
                var basket = session == null ? new Dictionary<Product, int>() : session as Dictionary<Product, int>;
                return basket;
            }
        }

        public static void Add(Product product, int quantity)
        {
            var products = HttpContext.Current.Session["Basket"] as Dictionary<Product, int>;
            if (products == null)
            {
                products = new Dictionary<Product, int>();
            }
            products[product] = quantity;


            HttpContext.Current.Session.Add("Basket", products);
        }
        public static void Remove(Product product, int quantity)
        {
            var products = HttpContext.Current.Session["Basket"] as Dictionary<Product, int>;
            if (quantity == 0)
            {
                products.Remove(product);
            }
            else
            {
                products[product] = quantity;
            }
            HttpContext.Current.Session.Add("Basket", products);
        }
    }
}
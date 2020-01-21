using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vektorel.EMarket.WebApi.Models
{
    [Serializable]
    public class ProductViewModel
    {
        
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public DateTime Date { get; set; }
    }
}
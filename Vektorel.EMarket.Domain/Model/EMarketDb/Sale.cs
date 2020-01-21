using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Sale : BaseEntity
    {
        public Sale()
        {
            SaleKey = Guid.NewGuid();
        }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public Guid SaleKey { get; set; }

   
    }
}

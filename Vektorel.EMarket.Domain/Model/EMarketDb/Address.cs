using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Address : BaseEntity
    {
        public string Door { get; set; }

        public string Building { get; set; }

        public string Street { get; set; }

        public string Avenue { get; set; }

        public string County { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public Guid CustomerKey { get; set; }

        public Customer Customer { get; set; }

    }
}

using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class InvoiceLine : BaseEntity
    {
        public Guid ProductKey { get; set; }


        public Product Product { get; set; }

        public string UnitType { get; set; }

        public int UnitValue { get; set; }

        public decimal Total { get; set; }

        public decimal TotalWithTax { get; set; }

        public decimal TaxRate { get; set; }


        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

    }
}

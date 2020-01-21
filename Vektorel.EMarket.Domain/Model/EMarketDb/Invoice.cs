using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Invoice : BaseEntity
    {
        public Invoice()
        {
            InvoiceNumber = Guid.NewGuid();
        }

        public Guid InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal Debit { get; set; }

        public Guid SaleKey { get; set; }

        public decimal Credit { get; set; }

        public decimal Balance { get; set; }

        public decimal TaxAppliedBalance { get; set; }


        public virtual  ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}

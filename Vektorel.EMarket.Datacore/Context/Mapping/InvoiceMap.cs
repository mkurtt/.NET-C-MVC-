using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class InvoiceMap : BaseEntityMap<Invoice>
    {
        public InvoiceMap()
        {
            ToTable(DbConstants.Invoices.Name, DbConstants.Invoices.Schema);

            Property(x => x.Balance)
                .HasColumnType("money")
                .IsRequired();

            Property(x => x.Debit)
               .HasColumnType("money")
               .IsRequired();

            Property(x => x.Credit)
               .HasColumnType("money")
               .IsRequired();
            

        }
    }
}

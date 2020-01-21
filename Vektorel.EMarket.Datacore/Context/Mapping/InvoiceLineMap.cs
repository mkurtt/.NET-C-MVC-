using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class InvoiceLineMap : BaseEntityMap<InvoiceLine>
    {
        public InvoiceLineMap()
        {
            ToTable(DbConstants.InvoiceLines.Name, DbConstants.InvoiceLines.Schema);

            Property(x => x.Total)
                .HasColumnType("money")
                .IsRequired();


            HasRequired(x => x.Invoice)
                .WithMany(x => x.InvoiceLines)
                .HasForeignKey(x => x.InvoiceId)
                .WillCascadeOnDelete(true);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{ 
    public class SaleMap : BaseEntityMap<Sale>
    {
        public SaleMap()
        {
            ToTable(DbConstants.Sales.Name, DbConstants.Sales.Schema);

            HasRequired(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId)
                .WillCascadeOnDelete(false);

            HasIndex(x => x.OrderId)
                .IsUnique(true);


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class OrderMap : BaseEntityMap<Order>
    {
        public OrderMap()
        {

            ToTable(DbConstants.Orders.Name, DbConstants.Orders.Schema);

            Property(x => x.OrderTotal)
                .HasColumnType("money")
                .IsRequired();

            Property(x => x.OrderNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            HasRequired(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerKey)
                .WillCascadeOnDelete(false);

            HasIndex(x => x.OrderNumber)
                .IsUnique(true);


            HasMany(x => x.Products)
                .WithMany(x => x.Orders)
                .Map(m =>
                {
                    m.MapLeftKey("OrderId");
                    m.MapRightKey("ProductId");
                    m.ToTable(DbConstants.OrderProducts.Name, DbConstants.OrderProducts.Schema);
                });
        }
    }
}

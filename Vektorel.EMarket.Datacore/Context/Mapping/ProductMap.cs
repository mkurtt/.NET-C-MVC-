using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class ProductMap : BaseEntityMap<Product>
    {
        public ProductMap()
        {
            ToTable(DbConstants.Products.Name, DbConstants.Products.Schema);

            Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

                


            HasRequired(x => x.User)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.UserId);


        }
    }
}

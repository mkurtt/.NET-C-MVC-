using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class CategoryMap : BaseEntityMap<Category>
    {
        public CategoryMap()
        {
            ToTable(DbConstants.Categories.Name, DbConstants.Categories.Schema);


            Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            HasRequired(x => x.Group)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.GroupId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Products)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);

        }
    }
}

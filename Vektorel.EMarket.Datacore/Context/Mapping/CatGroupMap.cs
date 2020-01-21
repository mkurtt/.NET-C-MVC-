using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class CatGroupMap : BaseEntityMap<CategoryGroup>
    {
        public CatGroupMap()
        {
            ToTable(DbConstants.CategoryGroups.Name, DbConstants.CategoryGroups.Schema);

            Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

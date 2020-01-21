using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            Property(x => x.CreatedAt)
                .HasColumnType("datetime2")
                .IsRequired();

            HasKey(x => x.Id);


            Property(x => x.UpdatedAt)
                .HasColumnType("datetime2")
                .IsRequired();

            
        }
    }
}

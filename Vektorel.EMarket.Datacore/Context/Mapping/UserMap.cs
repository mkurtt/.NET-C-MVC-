using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class UserMap :  BaseEntityMap<ApplicationUser>
    {
        public UserMap()
        {

            ToTable(DbConstants.ApplicationUsers.Name, DbConstants.ApplicationUsers.Schema);

            Property(x => x.Email)
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            HasIndex(x => x.Email)
                .IsUnique();


            Property(x => x.Password)
                .HasColumnType("nchar")
                .HasMaxLength(64)
                .IsRequired();

            Property(x => x.LastLogin)
                .HasColumnType("datetime2");
            

        }
    }
}

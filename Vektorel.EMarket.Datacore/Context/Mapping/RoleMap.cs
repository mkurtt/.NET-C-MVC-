using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class RoleMap : BaseEntityMap<Role>
    {
        public RoleMap()
        {
            ToTable(DbConstants.Roles.Name, DbConstants.Roles.Schema);


            Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired();

            HasIndex(x => x.Name)
                .IsUnique();


            HasMany(x => x.Users)
                .WithMany(x => x.Roles)
                .Map(m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserId");
                    m.ToTable(DbConstants.UserRoles.Name,DbConstants.UserRoles.Schema);
                });
        }
    }
}

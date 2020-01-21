using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class ModuleMap : BaseEntityMap<Module>
    {
        public ModuleMap()
        {
            ToTable(DbConstants.Modules.Name, DbConstants.Modules.Schema);


            Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsRequired();

            HasIndex(x => x.Name)
                .IsUnique();


            HasMany(x => x.Roles)
                .WithMany(x => x.Modules)
                .Map(m =>
                {
                    m.MapLeftKey("ModuleId");
                    m.MapRightKey("RoleId");
                    m.ToTable(DbConstants.RoleModules.Name, DbConstants.RoleModules.Schema);
                });
        }
    }
}

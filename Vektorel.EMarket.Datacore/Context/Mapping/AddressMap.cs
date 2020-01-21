using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;
using Vektorel.EMarket.Domain.Model.EMarketDb;

namespace Vektorel.EMarket.Datacore.Context.Mapping
{
    public class AddressMap : BaseEntityMap<Address>
    {
        public AddressMap()
        {
            ToTable(DbConstants.Addresses.Name, DbConstants.Addresses.Schema);
        }
    }
}

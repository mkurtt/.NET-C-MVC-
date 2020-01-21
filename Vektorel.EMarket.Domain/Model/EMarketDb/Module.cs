using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Module : BaseEntity
    {
        public string Name { get; set; }

        public string RouteOrPath { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}

using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }


        public virtual ICollection<ApplicationUser> Users { get; set; }


        public virtual ICollection<Module> Modules { get; set; }
    }
}

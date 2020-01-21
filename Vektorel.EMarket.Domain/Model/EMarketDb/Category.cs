using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public int GroupId { get; set; }

        public CategoryGroup Group { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }
        public new Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MainPicturePath { get; set; }

        public decimal UnitPrice { get; set; }

        public int DiscountRate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }




        public virtual ICollection<Order> Orders { get; set; }
    }
}

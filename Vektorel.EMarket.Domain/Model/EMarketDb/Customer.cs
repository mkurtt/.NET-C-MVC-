using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Customer : BaseEntity
    {

        public Customer()
        {
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string IdentityNumber { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public DateTime BirthDate { get; set; }


        public ApplicationUser User { get; set; }

        public int UserId { get; set; }


        public new Guid Id { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        public decimal Balance { get; set; }


        public virtual ICollection<Order> Orders { get; set; }


        public virtual  ICollection<Address> Addresses { get; set; }
    }
}

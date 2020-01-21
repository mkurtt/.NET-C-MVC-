using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class TicketResponse : BaseEntity
    {
        public string Content { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

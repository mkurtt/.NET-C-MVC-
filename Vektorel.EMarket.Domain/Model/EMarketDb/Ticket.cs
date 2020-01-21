using MAA.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;

namespace Vektorel.EMarket.Domain.Model.EMarketDb
{
    public class Ticket : BaseEntity
    {
        public string Head { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public TicketStatus Status { get; set; }
    }
}

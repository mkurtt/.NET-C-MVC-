using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Constants
{
    public enum OrderStatus
    {
        Waiting, Shipped, Cancelled, Finished
    }

    public enum TicketStatus
    {
        WaitingForResponse,OnGoing, Completed, Transfered
    }
}

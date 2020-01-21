using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vektorel.EMarket.Domain.Constants
{
    public enum UserResultType
    {
        Blocked,NotConfirmed,Authenticated,UnAuthorized,NotFound
    }

    public enum ApiMessageType
    {
        Success,Error,NotFound
    }

    public enum PaymentType
    {
        CreditCard, Bitcoin, PromotionCode
    }
    
}

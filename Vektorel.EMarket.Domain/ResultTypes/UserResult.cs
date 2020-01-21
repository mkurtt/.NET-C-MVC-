using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Model.EMarketDb;
using MAA.Basecore.Model.ResultTypes;
using Vektorel.EMarket.Domain.Constants;
using MAA.Basecore.Model.Enums;

namespace Vektorel.EMarket.Domain.ResultTypes
{
    public class UserResult : BusinessResult<ApplicationUser>
    {
        public UserResult(UserResultType userState,ApplicationUser u,string msg,BusinessResultType state)
            : base(u,msg,state)
        {
            UserState = userState;
        }

        public UserResultType UserState { get; set; }
    }
}

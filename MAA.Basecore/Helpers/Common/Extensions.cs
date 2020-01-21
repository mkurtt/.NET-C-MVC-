using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAA.Basecore.Helpers.Common
{
    public static class Extensions
    {
        public static int ToInt32(this object value)
        {
            int result = -1;
            int.TryParse(value.ToString(),out result);
            return result;
        }


        public static Exception GetOriginalException(this Exception exc)
        {
            if (exc.InnerException!=null)
            {
                exc.GetOriginalException();
            }
            return exc;
        }
    }
}

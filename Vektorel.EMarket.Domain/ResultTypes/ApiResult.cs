using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vektorel.EMarket.Domain.Constants;

namespace Vektorel.EMarket.Domain.ResultTypes
{
    public class ApiResult
    {

        public ApiResult(string msg, ApiMessageType messageType)
        {

            if (Result != null)
                Result.Clear();
            else
                Result = new Dictionary<string, object>();
            switch (messageType)
            {
                case ApiMessageType.Success:
                    Result.Add("status", true);
                    Result.Add("code", 40);
                    break;
                case ApiMessageType.Error:
                    Result.Add("status", false);
                    Result.Add("code", 41);
                    break;
                case ApiMessageType.NotFound:
                    Result.Add("status", false);
                    Result.Add("code", 42);
                    break;
            }
            Result.Add("type", messageType.ToString());
            Result.Add("message", msg);

        }

        public Dictionary<string, object> Result { get; set; }
    }

    public class ApiResult<T> : ApiResult
    {
        public ApiResult(T data,string msg = "", ApiMessageType messageType = ApiMessageType.Success)
            : base(msg,messageType)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}

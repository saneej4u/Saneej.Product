using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saneej.Product.Services
{
    public class ActionResponse<T>
    {
        public T Data { get; }

        public bool NotFound { get; }

        public bool IsClientError => ClientError?.Trim().Length > 0;
        public string ClientError { get; }
        public string NoFoundMessage { get; }

        public ActionResponse(T data)
        {
            if (data == null)
            {
                NotFound = true;
                return;
            }

            Data = data;
        }

        private ActionResponse(ActionResponse actionResponse)
        {
            ClientError = actionResponse.ClientError;
            NotFound = actionResponse.NotFound;
            NoFoundMessage = actionResponse.NotFoundMessage;
        }

        public static implicit operator ActionResponse<T>(ActionResponse ar)
        {
            return new ActionResponse<T>(ar);
        }

        public static implicit operator T(ActionResponse<T> t)
        {
            return t.Data;
        }
    }
}

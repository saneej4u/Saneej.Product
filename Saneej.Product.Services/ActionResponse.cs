using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saneej.Product.Services
{
    public class ActionResponse
    {
        public string ClientError { get; }
        public bool NotFound { get; }
        public string NotFoundMessage { get; }

        private ActionResponse(string clientError)
        {
            ClientError = clientError;
        }

        private ActionResponse(bool notFound, string notFoundMessage = null)
        {
            NotFound = notFound;
            NotFoundMessage = notFoundMessage;
        }

        public static ActionResponse CreateWithClientError(string clientError)
        {
            return new ActionResponse(clientError);
        }

        public static ActionResponse CreateNotFound(string notFoundMessage = null)
        {
            return new ActionResponse(true, notFoundMessage);
        }
    }
}

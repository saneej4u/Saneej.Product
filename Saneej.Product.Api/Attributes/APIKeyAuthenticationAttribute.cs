using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Saneej.Product.Api.Attributes
{
    public class APIKeyAuthenticationAttribute : Attribute, IAsyncActionFilter
    {
        private const string API_Key = "san-api-key";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool success = context.HttpContext.Request.Headers.TryGetValue(API_Key, out var apiKeyFromHttpHeader);
            if (!success)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "API Key is missing."
                };

                return;
            }

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appSettings.json");
            var Configuration = configurationBuilder.Build();

            string api_key_From_Configuration = Configuration[API_Key];

            if (!api_key_From_Configuration.Equals(apiKeyFromHttpHeader))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Invalid API Key"
                };

                return;
            }

            await next();
        }
    }
}

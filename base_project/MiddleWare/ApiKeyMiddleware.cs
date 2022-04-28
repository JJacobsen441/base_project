using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Base.Common;

namespace Base.MiddleWare
{
    /*
     * I found this code on the web, and have addapted it for my own style 
     * */

    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEY = "ApiKey";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string extracted_api_key = context.Request.Headers[APIKEY];
            string api_key = BaseConfiguration.Get().GetValue<string>(APIKEY);

            if(extracted_api_key.IsNullOrEmpty())
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided ");
                return;
            }
        
            if (!api_key.Equals(extracted_api_key))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            await _next(context);
        }
    }
}


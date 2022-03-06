using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication
{
    public class RoutingMiddleware
    {
        private RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/" || path == "/index")
                await context.Response.WriteAsync("HomePage");
            else if (path == "/about")
                await context.Response.WriteAsync("AboutPage");
            else
                context.Response.StatusCode = 404;
        }
    }
}

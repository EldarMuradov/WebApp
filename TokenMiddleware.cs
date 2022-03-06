using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication
{
    public class TokenWiddleware
    {
        private RequestDelegate _next;
        private string _pattern;
        public TokenWiddleware(RequestDelegate next, string pattern) 
        {
            _next = next;
            _pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            var token = context.Request.Query["token"];
            if (token != _pattern) 
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Invalid Token!");
            }
            else 
                await _next?.Invoke(context);
        }
    }

    public static class TokenExtensions 
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, 
            string pattern)
        {
            return builder.UseMiddleware<TokenWiddleware>(pattern);
        }
    }
}

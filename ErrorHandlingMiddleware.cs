using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next) 
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context,IApplicationBuilder app)
        {
            await _next?.Invoke(context);
            if (context.Response.StatusCode == 403) 
                await context.Response.WriteAsync("Access Denied!");
            else if (context.Response.StatusCode == 404)
                await context.Response.WriteAsync("Not Found!");
        }
    }
}

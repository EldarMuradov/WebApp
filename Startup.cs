using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Services;

namespace WebApplication
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICounter, RandomCounter>();
            services.AddTransient<CounterService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<CounterMiddleware>();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"\n hello {context.Request.Host.Value.ToString()}");
            });
        }           
    }
}

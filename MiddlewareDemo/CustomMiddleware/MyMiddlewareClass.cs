using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MiddlewareDemo.CustomMiddleware
{
    public class MyMiddlewareClass : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware - Starts\n");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware - Ends");

        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder Use(this IApplicationBuilder app)
        {
            //app.UseMiddleware<MyMiddlewareClass>()
            return app.UseMiddleware<MyMiddlewareClass>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace StubMiddleware
{
    public static class StubMiddlewareExtensions
    {
        public static IApplicationBuilder UseStubMiddleware(this IApplicationBuilder app, StubMiddlewareOptions options)
        {
            return app.Map(options.Route, mapApp =>
             {
                 mapApp.Run(async context =>
                 {
                     await context.Response.WriteAsync("Hello World!");
                 });
             });
        }
    }
}

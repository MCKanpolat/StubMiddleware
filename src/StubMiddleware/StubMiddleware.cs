using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StubMiddleware
{
    public class StubMiddleware
    {
        private readonly RequestDelegate _next;

        public StubMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            return _next(httpContext);
        }
    }
}

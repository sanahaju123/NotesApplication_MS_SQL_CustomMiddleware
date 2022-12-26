using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApplication.Middleware
{
    public class ThirdMiddleware
    {
        private readonly RequestDelegate _next;
        public ThirdMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Third Custom Middleware \n");
            await _next(httpContext);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ThirdMiddlewareExtensions
    {
        public static IApplicationBuilder UseThirdMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ThirdMiddleware>();
        }
    }
}

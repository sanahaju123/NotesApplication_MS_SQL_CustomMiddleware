using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NotesApplication.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApplication.Middleware
{
    public class SecondMiddleware
    {
        private readonly RequestDelegate _next;
        public SecondMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Second Custom Middleware \n");
            await _next(httpContext);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SecondMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecondMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SecondMiddleware>();
        }
    }
}

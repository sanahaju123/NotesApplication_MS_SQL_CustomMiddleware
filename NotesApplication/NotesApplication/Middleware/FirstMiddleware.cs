using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApplication.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("First Custom Middleware \n");
            await _next(httpContext);
        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FirstMiddlewareExtensions
    {
        public static IApplicationBuilder UseFirstMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstMiddleware>();
        }
    }
}

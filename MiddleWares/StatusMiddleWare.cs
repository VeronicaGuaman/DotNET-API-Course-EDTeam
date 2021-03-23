using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace newwebapi.MiddleWares
{
    public class StatusMiddleWare
    {
        readonly RequestDelegate next;
        public StatusMiddleWare(RequestDelegate nextRequest)
        {
            next = nextRequest;

        }
        public async Task Invoke(HttpContext context)
        {
            await next(context);

            if(context.Request.Query.Any(p => p.Key == "Status"))
            {
                await context.Response.WriteAsync("Working...");
            }
        }

    }

    public static class  StatusMiddleWarextension
    {
        public static IApplicationBuilder UserStatusMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StatusMiddleWare>();
        }
    }
}
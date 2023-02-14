using System.Net;
using Newtonsoft.Json;

namespace testforBohdan.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                Error = ex.Message,
                Status = context.Response.StatusCode
            }));
            return;
        }
    }
}
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;

namespace WebApi.Middlewares {
  public class CustomExpectionMiddleware {

    private readonly RequestDelegate _next;
    public CustomExpectionMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context){
      var watch = Stopwatch.StartNew();
      try {
        string message = "[REQUEST]  HTTP " + context.Request.Method + " - " + context.Request.Path;
        Console.WriteLine(message);

        await _next(context);
        watch.Stop();

        message = "[RESPONSE] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded with " + context.Response.StatusCode + " in " + + watch.Elapsed.TotalMilliseconds + "ms.";
        Console.WriteLine(message);
      }
      catch (Exception ex) {
        watch.Stop();
        await HandleException(context, ex, watch);
      }
    }

    private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      string message = "[ERROR]  HTTP " + context.Request.Method + " - " + context.Request.Path + "raised an error with [" + context.Response.StatusCode +"] " + ex.Message + ". in " + watch.Elapsed.TotalMilliseconds + "ms.";
      Console.WriteLine(message);

      var result = JsonConvert.SerializeObject(new {error = ex.Message}, Formatting.None);
      return context.Response.WriteAsync(result);
    }
  }
  public static class CustomExpectionMiddlewareExtension {
    public static IApplicationBuilder UseCustomExpectionMiddleware(this IApplicationBuilder builder) {
      return builder.UseMiddleware<CustomExpectionMiddleware>();
    }
  }
}
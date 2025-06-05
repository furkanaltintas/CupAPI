using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Context;
using System.Diagnostics;

namespace CupAPI.Persistence.Middlewares;

public class SerilogMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
{
    public async Task Invoke(HttpContext context)
    {
        var sw = Stopwatch.StartNew();

        var request = context.Request;
        var ip = context.Connection.RemoteIpAddress?.ToString();
        var claim = httpContextAccessor.HttpContext?.User.FindFirst("_e");
        var username = claim != null ? claim.Value : "Anonim";
        var requestPath = request.Path;

        using (LogContext.PushProperty("UserName", username))
        using (LogContext.PushProperty("RequestPath", requestPath))
        using (LogContext.PushProperty("RequestMethod", request.Method))
        using (LogContext.PushProperty("RequestIP", ip))
        {
            Log.Information("Gelen İstek: {Method} {Path} - IP: {IP}", request.Method, request.Path, ip);

            try
            {
                await next(context);
                sw.Stop();
                Log.Information("Yanıt: {StatusCode} - Süre: {Elapsed} ms", context.Response.StatusCode, sw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                sw.Stop();
                Log.Error(ex, "Hata oluştu. Süre: {Elapsed} ms", sw.ElapsedMilliseconds);
                throw;
            }
        }
    }
}
